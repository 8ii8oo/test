using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TigerPawHitbox : MonoBehaviour
{
    public GameObject WarningBoxPrefab;         // UI 경고창 프리팹
    public GameObject footGreenPrefab;          // 공격 이펙트 프리팹

    private GameObject warningBoxInstance;
    private Canvas uiCanvas;                    // 자동 생성 또는 찾기
    private Animator tigerAni;

    void Start()
    {
        // 1. 캔버스 자동으로 찾거나 생성
        uiCanvas = FindObjectOfType<Canvas>();
        if (uiCanvas == null)
        {
            GameObject canvasObj = new GameObject("Canvas", typeof(Canvas));
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();

            uiCanvas = canvasObj.GetComponent<Canvas>();
            
        }

  
        warningBoxInstance = Instantiate(WarningBoxPrefab, uiCanvas.transform);
        warningBoxInstance.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

     
        GameObject tigerObj = GameObject.Find("tiger");
        tigerAni = tigerObj.GetComponent<Animator>();
        tigerAni.SetTrigger("green");

    
        StartCoroutine(ShowWarningAndAttack());
    }

    IEnumerator ShowWarningAndAttack()
    {
        yield return new WaitForSeconds(0.5f);

        if (warningBoxInstance != null)
            Destroy(warningBoxInstance);

        Instantiate(footGreenPrefab, transform.position, Quaternion.identity);
    }
}
