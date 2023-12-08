using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;

    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < fruitPrefabs.Length; i++)
        {
            GameObject prefab = fruitPrefabs[i];
            Transform spawnPoint = spawnPoints[i];

            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

}
