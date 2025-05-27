using UnityEngine;
using System.Collections;

public class tigerMoveTset : MonoBehaviour
{
    Transform tigerPos;

    public Vector3 target = new Vector3(3.5f, 2.3f, 0f);
    Vector3 startPosition;
    float moveTime;
    bool isMoving;
    bool goingToTarget = true;

    void Start()
    {
        // 🔧 가장 안전한 방법: 자신의 Transform 사용
        tigerPos = transform;

        startPosition = tigerPos.position;
        moveTime = 0f;
        isMoving = true;

        StartCoroutine(SmoothRotate(-20f));
    }

    void Update()
    {
        if (!isMoving) return;

        moveTime += Time.deltaTime;
        float t = Mathf.Clamp01(moveTime / 0.5f);

        Vector3 from = goingToTarget ? startPosition : target;
        Vector3 to = goingToTarget ? target : startPosition;

        tigerPos.position = Vector3.Lerp(from, to, t); 

        if (t >= 1f)
        {
            isMoving = false;
            moveTime = 0f;

            if (goingToTarget)
                StartCoroutine(DelayBeforeReturn());
            else
                StartCoroutine(SmoothRotate(0f));
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
}
