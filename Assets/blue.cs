using UnityEngine;
using System.Collections;

public class blue : MonoBehaviour
{

    public float speed = 2f;
    bool  goingUp = true;
    private float topY;
    private float bottomY;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       float y = transform.position.y;
        topY = y + 1f;
        bottomY = y - 3f;
    }

    void Update()
    {
        if (goingUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            if (transform.position.y >= topY)
            {
                goingUp = false; // 방향 전환
            }
        }
        else
        {
             
        transform.Translate(Vector3.zero * Time.deltaTime);
            Invoke("Down", 1f);
            
        }
    }

    void Down()
    {
     
        transform.Translate(Vector3.down * Time.deltaTime * speed);
            if (transform.position.y <= bottomY)
            {
                Destroy(gameObject);
            }
    }
}