using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class jumptest : MonoBehaviour
{
    public float jumpPower;
    private bool isGrounded = true;
    public AudioSource sfxsource;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.state == GameState.Playing)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isGrounded = false;
                sfxsource.Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "floor")
        {
        isGrounded = true;
        }
    }
}