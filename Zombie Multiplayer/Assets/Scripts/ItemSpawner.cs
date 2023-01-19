using System.Collections;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI; 

// Item spawner randomly near player
public class ItemSpawner : MonoBehaviourPun {
    public GameObject[] items; 

    public float maxDistance = 5f; 

    public float timeBetSpawnMax = 7f;
    public float timeBetSpawnMin = 2f; 

    private float timeBetSpawn;
    private float lastSpawnTime;

    private void Start() {
        timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        lastSpawnTime = 0;
    }

    private void Update() {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            Spawn();
        }
    }

    private void Spawn() {
        Vector3 spawnPosition = GetRandomPointOnNavMesh(Vector3.zero, maxDistance);
        spawnPosition += Vector3.up * 0.5f;

        GameObject itemToCreate = items[Random.Range(0, items.Length)];

        GameObject item =
            PhotonNetwork.Instantiate(itemToCreate.name, spawnPosition,
                Quaternion.identity);

        StartCoroutine(DestroyAfter(item, 5f));
    }

    IEnumerator DestroyAfter(GameObject target, float delay) {
        yield return new WaitForSeconds(delay);

        if (target != null)
        {
            PhotonNetwork.Destroy(target);
        }
    }

    // Retrieving random position with NavMesh Mehtod
    private Vector3 GetRandomPointOnNavMesh(Vector3 center, float distance) {
        Vector3 randomPos = Random.insideUnitSphere * distance + center;

        NavMeshHit hit;

        NavMesh.SamplePosition(randomPos, out hit, distance, NavMesh.AllAreas);

        return hit.position;
    }
}