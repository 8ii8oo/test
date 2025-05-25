using UnityEngine;

public class tailAttack : MonoBehaviour
{
    public GameObject warning;
    public GameObject tailPrefab;

    private GameObject currentWarning;
    private GameObject spawnedTail;
    Transform tigerPos;
    Animator tigerAni;
    public float speed = 1f;


    void Start()
    {
        GameObject tigerObj = GameObject.Find("tiger");
        tigerPos = tigerObj.GetComponent<Transform>();
        tigerAni = tigerObj.GetComponent<Animator>();
        tigerAni.SetTrigger("lever");
        tigerPos.transform.Translate(speed * Time.deltaTime, 0, 0);
        
        Show();
        Invoke("TailMover", 0.6f);
        
    }

    void TailMover()
    {
 
        spawnedTail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
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

