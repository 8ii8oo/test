using UnityEngine;
using System.Collections;

public class yellowControll : MonoBehaviour
{
    public GameObject WarningBoxPrefab;
    public GameObject yellowPrefab;
    public Vector2 createPoint;
    public int SpawnerIndex;

    private GameObject warningBoxInstance;

    void Start()
    {
        if (SpawnerIndex == 4)
        {
            GameObject uiCanvas = GameObject.Find("Canvas");
            if (WarningBoxPrefab != null && uiCanvas != null)
            {
                warningBoxInstance = Instantiate(WarningBoxPrefab, uiCanvas.transform);
                RectTransform rect = warningBoxInstance.GetComponent<RectTransform>();
                rect.localPosition = createPoint;
                rect.anchorMin = rect.anchorMax = new Vector2(0.48f, 0);
                rect.pivot = new Vector2(1, 0);
            }

            StartCoroutine(ShowWarningAndAttack());
        }
    }

    IEnumerator ShowWarningAndAttack()
    {
        yield return new WaitForSeconds(0.8f);

        if (warningBoxInstance != null)
            Destroy(warningBoxInstance);

        if (yellowPrefab != null)
            Instantiate(yellowPrefab, yellowPrefab.transform.position, Quaternion.identity);
    }
}
