using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject redDes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redDes = GameObject.Find("red");
        Invoke("DestroySelf", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void DestroySelf()
    {
        Destroy(gameObject);

        if (gameObject == redDes)
        {
             Invoke("DestroySelf", 1f);
        }

    }
}