using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class jumptest : MonoBehaviour
{
    public float jumpPower;

    public AudioSource sfxsource;
    Rigidbody2D rigid;
    Animator jumpAni;
     private bool isGrounded = true;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        jumpAni = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.state == GameState.Playing)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                jumpAni.SetTrigger("jump");

                Invoke("JumpC", 0.1f);
                isGrounded = false;
                

            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor")
        {
            isGrounded = true;
        }
    }

    void JumpC()
    {
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        sfxsource.Play();
        

    }
}