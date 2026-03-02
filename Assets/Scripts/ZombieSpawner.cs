using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    [Header("Spawn Settings")]
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;

    void Awake()
    {
        Instance = this;
    }

    public void SpawnZombie()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}