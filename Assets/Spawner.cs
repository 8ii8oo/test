using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] gameObjects;

    int[] patternCounts = new int[5];  
    int currentPatternIndex = 0;
    int previousPatternIndex = -1;

    void OnEnable()
    {
        Invoke("Spawn", 2f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
    void Spawn()
    {
        // 다음 실행할 패턴 찾기 (카운트가 1 이상인 건 제외)
        int tries = 0;
        do
        {
            currentPatternIndex = Random.Range(0, gameObjects.Length);
            tries++;
        } while (patternCounts[currentPatternIndex] >= 1 && tries < 10);


        GameObject prefab = gameObjects[currentPatternIndex];
        Vector3 spawnPosition = new Vector3(prefab.transform.position.x, prefab.transform.position.y, 0f);
        Instantiate(prefab, spawnPosition, Quaternion.identity);

        patternCounts[currentPatternIndex]++;


        // 이전 패턴 기록
        previousPatternIndex = currentPatternIndex;

        Invoke("Spawn", 3.5f);
    }
}
