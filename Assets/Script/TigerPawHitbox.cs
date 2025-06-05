using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TigerPawHitbox : MonoBehaviour
{
    public GameObject WarningBoxPrefab;
    public GameObject footGreenPrefab;

    private GameObject warningBoxInstance;
    private Canvas uiCanvas;
    private Animator tigerAni;
    public Vector2 createPoint;


    private float moveTime;
    private Vector2 startPosition;
    Vector2 targetPosition = new Vector2(8f, 2.5f);
    public float moveSpeed = 1f;

private Transform tigerTransform;


    void Start()
    {
        
        GameObject uiCanvas = GameObject.Find("Canvas");

        if (WarningBoxPrefab != null)
        {


            warningBoxInstance = Instantiate(WarningBoxPrefab, uiCanvas.transform);

            RectTransform rectTransform = warningBoxInstance.GetComponent<RectTransform>();
            rectTransform.localPosition = createPoint;


            rectTransform.anchorMin = new Vector2(1f, 0);
            rectTransform.anchorMax = new Vector2(1f, 0);
            rectTransform.pivot = new Vector2(1, 0);
        }


        GameObject tigerObj = GameObject.Find("tiger");
        if (tigerObj != null)
        {
            tigerAni = tigerObj.GetComponent<Animator>();
            if (tigerAni != null)
            {
                tigerAni.SetTrigger("green");
            }
        }

        StartCoroutine(ShowWarningAndAttack());
    }



    void Update()
    {
        
    }

    IEnumerator ShowWarningAndAttack()
    {
        yield return new WaitForSeconds(1f);

        if (warningBoxInstance != null)
        {
            Destroy(warningBoxInstance);
        }


        if (footGreenPrefab != null)
        {
            Instantiate(footGreenPrefab, transform.position, Quaternion.identity);
        }

    }
}