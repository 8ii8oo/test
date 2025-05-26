using UnityEngine;

public class TigerPawController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("New Animation"); // 애니메이션 클립 이름 그대로
    }
}
