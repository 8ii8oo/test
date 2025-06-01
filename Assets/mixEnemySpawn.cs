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
        public string name; // 참고용 이름
        public GameObject[] patterns; // 조합할 프리팹들
    }

    [Header("패턴 조합 배열")]
    public PatternCombo[] patternCombos;

    void Start()
    {
        //랜덤으로 하나의 조합을 선택해서 동시에 소환
        int index = Random.Range(0, patternCombos.Length);
        SpawnPatternCombo(patternCombos[index]);
    }

    void SpawnPatternCombo(PatternCombo combo)
    {
        foreach (GameObject pattern in combo.patterns)
        {
            Instantiate(pattern, transform.position, Quaternion.identity);
        }
    }
}
