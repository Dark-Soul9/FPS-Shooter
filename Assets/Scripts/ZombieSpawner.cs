using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    [Header("Spawn Settings")]
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public float spawnDelay = 0.5f;

    void Awake()
    {
        Instance = this;
    }

    public void SpawnWave(int zombieCount)
    {
        StartCoroutine(SpawnWaveRoutine(zombieCount));
    }

    IEnumerator SpawnWaveRoutine(int zombieCount)
    {
        List<Transform> availableSpawns = new List<Transform>(spawnPoints);

        int spawnAmount = Mathf.Min(zombieCount, availableSpawns.Count);

        ShuffleList(availableSpawns);

        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(zombiePrefab,
                availableSpawns[i].position,
                availableSpawns[i].rotation);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void ShuffleList(List<Transform> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Transform temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}