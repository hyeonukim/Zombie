using Photon.Pun;
using UnityEngine;

// Item class: Increases the score
public class Coin : MonoBehaviourPun, IItem {
    public int score = 200; 

    public void Use(GameObject target) {
        GameManager.instance.AddScore(score);
        PhotonNetwork.Destroy(gameObject);
    }
}