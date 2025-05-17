using UnityEngine;

public class realTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
transform.Rotate(0, 0, 10 * Time.deltaTime);
        if (transform.eulerAngles.z > 9)
        {
            transform.Rotate(0, 0, -10 * Time.deltaTime);

            
        }
    }
        
}
