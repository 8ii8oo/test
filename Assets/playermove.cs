using UnityEngine;
using UnityEngine.InputSystem;

public class playermove : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject BulletPrefab;
    public float BulletSpeed;


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed *Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed *Time.deltaTime, 0, 0);
        }
        
    }
}
