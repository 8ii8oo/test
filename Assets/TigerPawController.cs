using UnityEngine;

public class TigerPawController : MonoBehaviour
{
    Vector3 target = new Vector3(4.57f, -2.2f, 0f);
    Animator tigerAni;
    GameObject footGreenPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, 0.01f);
    }

   
}
