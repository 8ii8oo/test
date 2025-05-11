using UnityEngine;

public class tail : MonoBehaviour
{
    public GameObject warning;
    public float speed = 5000.0f;
    public GameObject enemyTailPrefab;
    private GameObject currentWarning;
    void Start()
    {
        Show();
        Invoke("TailMover", 0.6f);
        
    }
   

    void Update()
    {
         if (transform.position.x >= -0.05f)
    {
        Destroy(gameObject);
    }
    }

    void TailMover()
    {

       GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
       
    }

    void Show()
{
 GameObject canvas = GameObject.Find("Canvas");

    GameObject warningInstance = Instantiate(warning, canvas.transform);
    warningInstance.SetActive(true);
    Invoke("Hide", 0.6f);


    currentWarning = warningInstance;
    
}

    void Hide()
{
    if (currentWarning != null)
    {
        Destroy(currentWarning);
    }
}

}
