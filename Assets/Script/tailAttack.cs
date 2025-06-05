using UnityEngine;
using System.Collections;

public class tailAttack : MonoBehaviour
{
    public GameObject warning;
    public GameObject tailPrefab;

    private GameObject currentWarning;
    private GameObject spawnedTail;
    Transform tigerPos;
    Animator tigerAni;

    public float speed = 1f;
    Vector3 target = new Vector3(3.5f, 2.3f, 0f);

    bool isMoving;
    bool goingToTarget = true;
    Vector2 startPosition;
    Vector2 targetPosition;
    float moveTime;

    void Start()
    {
        GameObject tigerObj = GameObject.Find("tiger");
        tigerPos = tigerObj.GetComponent<Transform>();
        tigerAni = tigerObj.GetComponent<Animator>();
        tigerAni.SetTrigger("lever");

        Show();
        Invoke("TailMover", 0.2f);

        startPosition = tigerPos.position;
        targetPosition = target;
        moveTime = 0;
        isMoving = true;

        StartCoroutine(SmoothRotate(goingToTarget ? -20f : 20f));
        
    }

    void Update()
    {
        if (isMoving)
        {
            moveTime += Time.deltaTime;
            float t = moveTime / 0.5f;
            t = Mathf.Clamp01(t);

            if (goingToTarget)
                tigerPos.position = Vector2.Lerp(startPosition, targetPosition, t);
            else
                tigerPos.position = Vector2.Lerp(targetPosition, startPosition, t);

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

    IEnumerator DelayBeforeReturn()
    {
        StartCoroutine(SmoothRotate(0f));
        yield return new WaitForSeconds(1f);
        goingToTarget = false;
        isMoving = true;

        StartCoroutine(SmoothRotate(20f));
    }

    IEnumerator SmoothRotate(float targetZ)
    {
        Quaternion startRot = tigerPos.rotation;
        Quaternion endRot = Quaternion.Euler(0, 0, targetZ);
        float duration = 0.3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            tigerPos.rotation = Quaternion.Lerp(startRot, endRot, elapsed / duration);
            yield return null;
        }

        tigerPos.rotation = endRot;
    }

    void TailMover()
    {
        spawnedTail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
    }

    void Show()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject warningInstance = Instantiate(warning, canvas.transform);
        warningInstance.SetActive(true);
        Invoke("Hide", 0.6f);
        currentWarning = warningInstance;
    }

    void Hide()
    {
        if (currentWarning != null)
        {
            Destroy(currentWarning);
        }
    }
}
