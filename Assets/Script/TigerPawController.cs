using UnityEngine;

public class TigerPawController : MonoBehaviour
{
    Vector3 startPosition = new Vector3(4.57f, 0.47f, 0f);
    Vector3 targetPosition = new Vector3(4.57f, -2.2f, 0f);
    Vector3 nextPosition = new Vector3(9f, -2.08f, 0f);

    float moveTime = 0f;
    float duration = 0.5f;
    bool toFirstTarget = true;
    bool toNextPosition = false;

    void Start()
    {
        transform.position = startPosition;
    }

    void Update()
    {
        moveTime += Time.deltaTime;
        float t = Mathf.Clamp01(moveTime / duration);

        if (toFirstTarget)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            if (t >= 1f)
            {
                toFirstTarget = false;
                toNextPosition = true;
                moveTime = 0f;

                startPosition = transform.position;
            }
        }
        else if (toNextPosition)
        {
            transform.position = Vector3.Lerp(startPosition, nextPosition, t);

            if (t >= 1f)
            {
                toNextPosition = false;
            }
        }
    }
}
