using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class yellowControll : MonoBehaviour
{
    public GameObject WarningBoxPrefab;
    public GameObject yellowPrefab;

    private GameObject warningBoxInstance;
    private Canvas uiCanvas;
    private Animator tigerAni;
    public Vector2 createPoint;
    private bool isMoving = false;
    private bool goingToTarget = true;
    private float moveTime;
    private Vector2 startPosition;
    Vector2 targetPosition = new Vector2(4.5f, 2f);
    public float moveSpeed = 1f;

    private Transform tigerTransform;





    void Start()
    {


        uiCanvas = FindFirstObjectByType<Canvas>();
        tigerTransform = GameObject.Find("tiger").GetComponent<Transform>();
        startPosition = tigerTransform.position;

        if (WarningBoxPrefab != null)
        {

            moveTime = 0;
            isMoving = true;


            StartCoroutine(SmoothRotate(goingToTarget ? -20f : 20f));

            warningBoxInstance = Instantiate(WarningBoxPrefab, uiCanvas.transform);

            RectTransform rectTransform = warningBoxInstance.GetComponent<RectTransform>();
            rectTransform.localPosition = createPoint;


            rectTransform.anchorMin = new Vector2(0.48f, 0);
            rectTransform.anchorMax = new Vector2(0.48f, 0);
            rectTransform.pivot = new Vector2(1, 0);
        }


        GameObject tigerObj = GameObject.Find("tiger");
        if (tigerObj != null)
        {
            tigerAni = tigerObj.GetComponent<Animator>();
            if (tigerAni != null)
            {
                tigerAni.SetTrigger("yellow");
            }
        }

        StartCoroutine(ShowWarningAndAttack());
    }



    void Update()
    {
        
        if (isMoving)
        {
            moveTime += Time.deltaTime;
            float t = moveTime / 0.77f;
            t = Mathf.Clamp01(t);

            if (goingToTarget)
                tigerTransform.position = Vector2.Lerp(startPosition, targetPosition, t);
            else
                tigerTransform.position = Vector2.Lerp(targetPosition, startPosition, t);

            if (t >= 1f)
            {
                isMoving = false;
                moveTime = 0f;

                if (goingToTarget)
                {
                    StartCoroutine(DelayBeforeReturn());
                }
                else
                {
                    StartCoroutine(SmoothRotate(0f));
                }
            }
        }
    }


    IEnumerator SmoothRotate(float targetZ)
    {
        Quaternion startRot = tigerTransform.rotation;
        Quaternion endRot = Quaternion.Euler(0, 0, targetZ);
        float duration = 0.3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            tigerTransform.rotation = Quaternion.Lerp(startRot, endRot, elapsed / duration);
            yield return null;
        }

        tigerTransform.rotation = endRot;
    }



    IEnumerator DelayBeforeReturn()
    {
        StartCoroutine(SmoothRotate(0f));
        yield return new WaitForSeconds(1.3f);
        goingToTarget = false;
        isMoving = true;
        StartCoroutine(SmoothRotate(20f));
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