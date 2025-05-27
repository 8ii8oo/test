using UnityEngine;

public class TigerPawController : MonoBehaviour
{
    Vector3 target = new Vector3(4.57f, -2.2f, 0f);

    Vector3 startPosition = new Vector3(4.57f, 0.47f, 0f);
    float moveTime = 0f;
    void Start()
    {
        transform.position = startPosition;
    }

    void Update()
    {
        moveTime += Time.deltaTime;
            float t = moveTime / 0.5f;
            t = Mathf.Clamp01(t);
        transform.position = Vector3.Lerp(startPosition, target, t);
    }
}