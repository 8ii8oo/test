using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject[] gameObjects; // 10개 프리팹 (0~9)

    int currentPatternIndex = 0;
    List<int> firstIndices = new List<int>(); // 초기 0~4 중 중복 없이 담을 리스트
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
        Instantiate(prefab, spawnPosition, Quaternion.identity);

        Invoke("Spawn", 3.5f);
    }
}
