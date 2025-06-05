using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class yellowControll : MonoBehaviour
{
    public GameObject WarningBoxPrefab;
    public GameObject yellowPrefab;
    public Vector2 createPoint;

    private GameObject warningBoxInstance;

    void Start()
    {
        // UI 생성
        GameObject uiCanvas = GameObject.Find("Canvas");
        if (WarningBoxPrefab != null && uiCanvas != null)
        {
            warningBoxInstance = Instantiate(WarningBoxPrefab, uiCanvas.transform);

            RectTransform rectTransform = warningBoxInstance.GetComponent<RectTransform>();
            rectTransform.localPosition = createPoint;
            rectTransform.anchorMin = new Vector2(0.48f, 0);
            rectTransform.anchorMax = new Vector2(0.48f, 0);
            rectTransform.pivot = new Vector2(1, 0);
        }




        // 공격 발사 코루틴 실행
        StartCoroutine(ShowWarningAndAttack());
    }

    IEnumerator ShowWarningAndAttack()
    {
        yield return new WaitForSeconds(0.8f);

        if (warningBoxInstance != null)
        {
            Destroy(warningBoxInstance);
        }

        if (yellowPrefab != null)
        {
            Instantiate(yellowPrefab, yellowPrefab.transform.position, Quaternion.identity);
        }
    }
}