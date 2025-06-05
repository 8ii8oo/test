using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject redDes;
    GameObject yellowDes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redDes = GameObject.Find("red");
        yellowDes = GameObject.Find("Yellow");
        Invoke("DestroySelf", 0.5f);


    }

    // Update is called once per frame
    void Update()
    {

    }
    void DestroySelf()
    {


        if (gameObject.name.Contains("red"))
        {
            Invoke("Dead", 1.5f);
        }
        else if (gameObject == yellowDes)
        {
            Invoke("Dead", 2f);
        }
        else
        {
            Invoke("Dead", 0.5f);
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}