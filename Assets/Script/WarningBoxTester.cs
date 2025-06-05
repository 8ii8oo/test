using UnityEngine;
using System.Collections;

public class WarningBoxTester : MonoBehaviour
{
    public GameObject warningBoxYellow;

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
        warningBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningBox.SetActive(false);

        tigerPaw.SetActive(true);
        tigerAnimator.Play("New Animation");

        yield return new WaitForSeconds(3f);
        tigerPaw.SetActive(false);
    }
}
