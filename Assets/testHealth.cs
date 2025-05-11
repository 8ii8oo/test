using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class testHealth : MonoBehaviour
{

    public BoxCollider2D PlayerCollider;
    public Rigidbody2D PlayerRigid;
    private float jumpPower = 5f;
    public Image[] heart;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public cameraShake cameraShake;
    private SpriteRenderer sr;
    

     private bool isInvincible = false;
     public float score;


void Start()
{
    UpdateHearts(); // 시작할 때 하트 그려주기
    sr = GetComponent<SpriteRenderer>();
}

    public void UpdateHearts()
{
    for (int i = 0; i < heart.Length; i++)
    {
        heart[i].sprite = emptyHeart;
    }

    for (int i = 0; i < Mathf.Min(GameManager.Instance.Live, heart.Length); i++)
    {
        heart[i].sprite = fullHeart;
    }
}
    public void KillPlayer()
{
    
    PlayerRigid.linearVelocity = Vector2.zero;
    PlayerRigid.AddForce(Vector2.up*jumpPower, ForceMode2D.Impulse);

}
    void Hit()
    {
        StartCoroutine(cameraShake.Shake(0.2f, 0.1f));
        GameManager.Instance.Live -= 1;
        UpdateHearts();
        StartInvincible();
        StartCoroutine(DamageEffect());
        
    }

  private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy") && !isInvincible)
        {
            Hit();
        }
    }

     void StartInvincible()
    {
        isInvincible = true;
        Invoke("EndInvincible", 2f);
        
    }

    void EndInvincible()
    {
        isInvincible = false;
        Debug.Log("무적끝");
        sr.color = new Color(1, 1, 1, 1);
    }


    IEnumerator DamageEffect()
    {
        

        for(int i = 0; i < 5; i++)
        {
           
            sr.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.2f);
            sr.color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(0.2f);
        }
    }

    
}