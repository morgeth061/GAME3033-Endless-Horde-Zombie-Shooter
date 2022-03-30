using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public int numberOfZombiesToSpawn;
    public GameObject[] zombiePrefab;
    public SpawnerVolume[] spawnVolumes;

    private GameObject followGameObject;

    void Start()
    {
        followGameObject = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < numberOfZombiesToSpawn; i++)
        {
            SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        GameObject zombieToSpawn = zombiePrefab[Random.Range(0, zombiePrefab.Length)];
        SpawnerVolume spawnVolume = spawnVolumes[Random.Range(0, spawnVolumes.Length)];

        if (!followGameObject) return;

        GameObject zombie =
            Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

        zombie.GetComponent<ZombieComponent>().Initialize(followGameObject);
    }
}
