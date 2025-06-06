using UnityEngine;

public class spawnerDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DestroySelf", 4f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
