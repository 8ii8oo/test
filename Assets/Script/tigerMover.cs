using UnityEngine;
using System.Collections;

public class TigerMover : MonoBehaviour
{
    public static TigerMover Instance;

    private Animator tigerAni;
    private Transform tigerTransform;

    private bool isMoving = false;
    private bool goingToTarget = true;
    private float moveTime = 0f;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private bool shouldRotateTiger = true;

    void Awake()
    {
        Instance = this;
    }

    public void StartYellowMove()
    {
        PrepareTigerMove(new Vector2(4.5f, 2f), "yellow", -20f, shouldRotate: true);
    }

    public void StartLeverMove()
    {
        PrepareTigerMove(new Vector2(3.5f, 2.3f), "lever", -20f);
    }

    public void StartGreenMove()
    {
        PrepareTigerMove(new Vector2(8f, 2.5f), "green", -20f);
    }

    public void StartBlueMove()
    {
        PrepareTigerMove(new Vector2(0f, 5f), "blue", 0f, shouldRotate: false);
    }

    public void StartRedMove()
    {
        PrepareTigerMove(new Vector2(0f, 2.4f), "red", 0f, shouldRotate: false);
    }

    public void StartMixMove()
    {
        PrepareTigerMove(new Vector2(0f, 5f), "lever", 0f, shouldRotate: false);
    }

    void PrepareTigerMove(Vector2 targetPos, string animationTrigger, float initialRotationZ, bool shouldRotate = true)
    {
        tigerTransform = GameObject.Find("tiger").transform;
        tigerAni = tigerTransform.GetComponent<Animator>();

        if (tigerAni != null)
            tigerAni.SetTrigger(animationTrigger);

        startPosition = tigerTransform.position;
        targetPosition = targetPos;
        goingToTarget = true;
        moveTime = 0f;
        isMoving = true;
        shouldRotateTiger = shouldRotate;

        if (shouldRotateTiger)
        {
            StartCoroutine(SmoothRotate(initialRotationZ));
        }
    }

    void Update()
    {
        if (!isMoving) return;

        moveTime += Time.deltaTime;
        float t = Mathf.Clamp01(moveTime / 0.5f);
        tigerTransform.position = Vector2.Lerp(startPosition, targetPosition, t);

        if (t >= 1f)
        {
            isMoving = false;
            moveTime = 0f;

            StartCoroutine(SmoothRotate(0f)); 

            if (goingToTarget)
                StartCoroutine(DelayBeforeReturn());
        }
    }

    IEnumerator DelayBeforeReturn()
    {
        yield return new WaitForSeconds(1f);
        goingToTarget = false;
        isMoving = true;

        Vector2 temp = startPosition;
        startPosition = targetPosition;
        targetPosition = temp;

        if (shouldRotateTiger)
        {
            StartCoroutine(SmoothRotate(20f));
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
}
