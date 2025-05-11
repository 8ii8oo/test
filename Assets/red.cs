using UnityEngine;

public class red : MonoBehaviour
{
    public float speed = 5f;

    public GameObject redPrefab;
    void Start()
    {
        RedPattern();
    } 

    void RedPattern()
    {
       Vector2 baseDir = Vector2.down;
    float[] angleOffsets = { -55f, 0f, 55f };

    for (int i = -1; i < 2; i++)
    {
        GameObject redCopy = Instantiate(redPrefab);

        Vector2 posVec = transform.position;
        posVec.x += 1f * i;
        if(i != 0)
        {
            posVec.y += 0.5f;
        }
        redCopy.transform.position = posVec;

        redCopy.transform.rotation = Quaternion.Euler(0, 0, angleOffsets[i + 1]);


        float angleInRadians = angleOffsets[i + 1] * Mathf.Deg2Rad;
        Vector2 rotatedDir = new Vector2(Mathf.Sin(angleInRadians), -Mathf.Cos(angleInRadians));


        Rigidbody2D rigid = redCopy.GetComponent<Rigidbody2D>();
        rigid.AddForce(rotatedDir.normalized * speed, ForceMode2D.Impulse);
 
        }
    }
}