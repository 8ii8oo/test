using System.Collections;
using UnityEngine;

public class mixEnemySpawn : MonoBehaviour
{

    //손톱 + 깨물기
    //손톱 + 앞발
    //손톱 + 꼬리 (살짝 텀 있게)
    //음파 + 깨물기
    //음파 + 앞발
    //꼬리 + 깨물기
    //꼬리 + 앞발

    [Header("기본 프리팹")]
    public GameObject clawPrefab;
    public GameObject tailPrefab;
    public GameObject footPrefab;
    public GameObject soundWavePrefab;
    public GameObject chewPrefab;

    [System.Serializable]
    public class PatternCombo
    {
        public string name; 
        public GameObject[] patterns; 
    }

    [Header("패턴 조합 배열")]
    public PatternCombo[] patternCombos;

    void Start()
    {
        int index = Random.Range(0, patternCombos.Length);
         StartCoroutine(SpawnPatternCombo(patternCombos[index]));
        
    }

    IEnumerator SpawnPatternCombo(PatternCombo combo)
{
    foreach (GameObject pattern in combo.patterns)
    {
        if (pattern != null)
        {
            Vector3 spawnPos = transform.position;
            GameObject instance = Instantiate(pattern, spawnPos, Quaternion.identity);
            instance.transform.SetParent(null);
        }

        yield return new WaitForSeconds(0f);
    }
}
}
