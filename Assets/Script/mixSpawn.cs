using UnityEngine;
using System.Collections;

public class mixSpawn : MonoBehaviour
{
    [Header("조합할 기본 프리팹 2개")]
    public GameObject pattern1;
    public GameObject pattern2;

    [Header("오프셋 (선택)")]
    public Vector2 offset1 = Vector2.zero;
    public Vector2 offset2 = Vector2.zero;

    [Header("mixSpawn 시 tiger 무빙")]
    public bool moveTigerOnMix = true;
    public float moveHeight = 2f;
    public float moveDuration = 0.5f;
    public float tigerRotateZ = 20f;

    void Start()
    {
        // 먼저 tiger 움직임 시작
        if (moveTigerOnMix)
        {
            StartCoroutine(MoveTigerUpAndDown());
        }

        // pattern1 소환
        if (pattern1 != null)
        {
            GameObject p1 = Instantiate(pattern1, transform.position + (Vector3)offset1, Quaternion.identity);
            DisableTigerMovementIfExists(p1);
        }

        // pattern2 소환
        if (pattern2 != null)
        {
            GameObject p2 = Instantiate(pattern2, transform.position + (Vector3)offset2, Quaternion.identity);
            DisableTigerMovementIfExists(p2);
        }
    }

    void DisableTigerMovementIfExists(GameObject obj)
    {
        var claw = obj.GetComponent<clawMover>();
        if (claw != null)
        {
            //claw.isMixedPattern = true;
        }

        var yellow = obj.GetComponent<yellowControll>();
        if (yellow != null)
        {
            //yellow.isMixedPattern = true;
        }
    }

    IEnumerator MoveTigerUpAndDown()
    {
        GameObject tigerObj = GameObject.Find("tiger");
        if (tigerObj == null) yield break;

        Transform tiger = tigerObj.transform;
        Vector3 startPos = tiger.position;
        Quaternion startRot = tiger.rotation;

        Vector3 targetPos = startPos + Vector3.up * moveHeight;
        Quaternion targetRot = Quaternion.Euler(0, 0, tigerRotateZ);

        // 올라가기
        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            float t = elapsed / moveDuration;
            tiger.position = Vector3.Lerp(startPos, targetPos, t);
            tiger.rotation = Quaternion.Lerp(startRot, targetRot, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        tiger.position = targetPos;
        tiger.rotation = targetRot;

        yield return new WaitForSeconds(0.5f);

        // 내려가기
        elapsed = 0f;
        while (elapsed < moveDuration)
        {
            float t = elapsed / moveDuration;
            tiger.position = Vector3.Lerp(targetPos, startPos, t);
            tiger.rotation = Quaternion.Lerp(targetRot, startRot, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        tiger.position = startPos;
        tiger.rotation = startRot;
    }
}
