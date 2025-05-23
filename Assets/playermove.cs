using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class playermove : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public SpriteRenderer stopFlip;
    Animator playerAnimator;





    void Awake()
    {
        playerAnimator = GetComponent<Animator>();

    }

    public void Update()
    {

        if (GameManager.Instance.state == GameState.Playing)
        {
            playerAnimator.SetFloat("speed", 0);

            if (Input.GetKey(KeyCode.A))
            {

                this.transform.Translate(-speed * Time.deltaTime, 0, 0);
                stopFlip.flipX = false;
                playerAnimator.SetFloat("speed", 1);

            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(speed * Time.deltaTime, 0, 0);
                stopFlip.flipX = true;
                playerAnimator.SetFloat("speed", 1);

            }
        }

    }

    
}
