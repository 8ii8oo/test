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
    float[] angleOffsets = { -48f, -23f, 0f, 23f, 48f };

    for (int i = 0; i < 5; i++)
    {
        GameObject redCopy = Instantiate(redPrefab);

        Vector2 posVec = transform.position;
        posVec.x += (i - 2) * 1f;

        float angleOffset = angleOffsets[i];
        float yOffset = Mathf.Abs(angleOffset) / 55f * 1f;  
        posVec.y += yOffset;

        redCopy.transform.position = posVec;

        redCopy.transform.rotation = Quaternion.Euler(0, 0, angleOffsets[i]);


        float angleInRadians = angleOffsets[i] * Mathf.Deg2Rad;
        Vector2 rotatedDir = new Vector2(Mathf.Sin(angleInRadians), -Mathf.Cos(angleInRadians));


        Rigidbody2D rigid = redCopy.GetComponent<Rigidbody2D>();
        rigid.AddForce(rotatedDir.normalized * speed, ForceMode2D.Impulse);
 
        }
    }
}