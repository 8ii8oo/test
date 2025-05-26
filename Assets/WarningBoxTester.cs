using UnityEngine;
using System.Collections;

public class WarningBoxTester : MonoBehaviour
{
    // Paw foot
    //사용 ㄴㄴㄴㄴㄴㄴㄴㄴㄴ
    //ㄴㄴㄴㄴ
    //ㄴㄴㄴㄴ

    public GameObject warningBox;
    public GameObject tigerPaw;

    private Animator tigerAnimator;

    void Start()
    {
        tigerPaw.SetActive(false); // 시작 시 발 숨기기
        tigerAnimator = tigerPaw.GetComponent<Animator>();
        StartCoroutine(ShowWarningAndAttack());
    }

    IEnumerator ShowWarningAndAttack()
    {
        // 1. 경고 박스 표시
        warningBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningBox.SetActive(false);

        // 2. 발바닥 등장 + 애니메이션 실행
        tigerPaw.SetActive(true);
        tigerAnimator.Play("footGreenAni");

        // 3. 애니메이션 끝나고 발바닥 숨김
        yield return new WaitForSeconds(1f); // 애니메이션 길이만큼 대기
        tigerPaw.SetActive(false);
    }
}
