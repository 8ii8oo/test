using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject[] gameObjects;

    int currentPatternIndex = 0;
    List<int> firstIndices = new List<int>();
    bool firstFiveDone = false;

    void OnEnable()
    {
        InitFirstIndices();
        Invoke("Spawn", 2f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void InitFirstIndices()
    {
        List<int> pool = new List<int> { 0, 1, 2, 3, 4 };

        while (pool.Count > 0)
        {
            int rand = Random.Range(0, pool.Count);
            firstIndices.Add(pool[rand]);
            pool.RemoveAt(rand);
        }
    }

    void Spawn()
    {
        if (!firstFiveDone)
        {
            currentPatternIndex = firstIndices[0];
            firstIndices.RemoveAt(0);

            if (firstIndices.Count == 0)
                firstFiveDone = true;
        }
        else
        {
            currentPatternIndex = Random.Range(0, gameObjects.Length);
        }

        GameObject prefab = gameObjects[currentPatternIndex];
        Vector3 spawnPosition = new Vector3(prefab.transform.position.x, prefab.transform.position.y, 0f);
        GameObject obj = Instantiate(prefab, spawnPosition, Quaternion.identity);

        if (currentPatternIndex == 4)
        {
            TigerMover.Instance?.StartYellowMove();
        }

        else if (currentPatternIndex == 2)
        {
            TigerMover.Instance.StartLeverMove();
        }

        else if (currentPatternIndex == 1)
        {
            TigerMover.Instance.StartGreenMove();
        }

        else if (currentPatternIndex == 0)
        {
            TigerMover.Instance.StartBlueMove();
        }

        else if (currentPatternIndex == 3)
        {
            TigerMover.Instance.StartRedMove();
        }

        else
        {
            TigerMover.Instance.StartMixMove();
        }

        Invoke("Spawn", 3.5f);
    }
}
