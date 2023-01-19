using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameManager
public class GameManager : MonoBehaviourPunCallbacks, IPunObservable {
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }

            return m_instance;
        }
    }

    private static GameManager m_instance; 

    public GameObject playerPrefab; 

    private int score = 0;
    public bool isGameover { get; private set; }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting)
        {
            stream.SendNext(score);
        }
        else
        {
            score = (int) stream.ReceiveNext();
            UIManager.instance.UpdateScoreText(score);
        }
    }

    //If there is another GameManager destroy itself
    private void Awake() {
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //Spawn player
    private void Start() {
        Vector3 randomSpawnPos = Random.insideUnitSphere * 5f;
        randomSpawnPos.y = 0f;

        PhotonNetwork.Instantiate(playerPrefab.name, randomSpawnPos, Quaternion.identity);
    }

    //Add score and update UI
    public void AddScore(int newScore) {
        if (!isGameover)
        {
            score += newScore;
            UIManager.instance.UpdateScoreText(score);
        }
    }

    // When game is over
    public void EndGame() {
        isGameover = true;
        UIManager.instance.SetActiveGameoverUI(true);
    }

    // Leaving the current room
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    // When user leaves the game bring them to 'lobby' scene
    public override void OnLeftRoom() {
        SceneManager.LoadScene("Lobby");
    }
}