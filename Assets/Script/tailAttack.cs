using UnityEngine;
using System.Collections;

public class tailAttack : MonoBehaviour
{
    public GameObject warning;
    public GameObject tailPrefab;

    private GameObject currentWarning;
    private GameObject spawnedTail;
    Transform tigerPos;
    Animator tigerAni;

    public float speed = 1f;
    Vector3 target = new Vector3(3.5f, 2.3f, 0f);

    bool isMoving;

    Vector2 startPosition;
    Vector2 targetPosition;
    float moveTime;

    void Start()
    {

        Show();
        Invoke("TailMover", 0.2f);
        
    }

    void Update()
    {
       
    }

    void TailMover()
    {
        spawnedTail = Instantiate(tailPrefab, tailPrefab.transform.position, Quaternion.identity);
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