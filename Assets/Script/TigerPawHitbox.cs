using UnityEngine;

public class TigerPawHitbox : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("🐾 TigerPawHitbox 활성화됨 (OnEnable 호출)");
    }

    private void Start()
    {
        Debug.Log("🐾 TigerPawHitbox Start 실행됨 (Collider 설정됨?)");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("🐾 충돌 감지됨! 이 오브젝트: " + gameObject.name + ", 대상: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("🔥 플레이어 타격 성공! (" + other.name + ")");
            // 추후: other.GetComponent<PlayerHealth>().TakeDamage(1);
        }
        else
        {
            Debug.Log("ℹ️ 태그가 'Player'가 아님: " + other.tag);
        }
    }
}
