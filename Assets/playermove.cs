using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class playermove : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public SpriteRenderer mover;
    Animator ani;


    void Start()
    {
        ani = GetComponent<Animator>();
        mover = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        ani.enabled = false;
        if (GameManager.Instance.state == GameState.Playing)
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(-speed * Time.deltaTime, 0, 0);
                mover.flipX = false;
                ani.enabled = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(speed * Time.deltaTime, 0, 0);
                ani.enabled = true;
                mover.flipX = true;
            }
        }

    }

    
}
