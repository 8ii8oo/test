using UnityEngine;

using System.Collections;
public class clawMover : MonoBehaviour

//blue

{
    
    public GameObject warningBlueUIPrefab;
    public GameObject enemyBluePrefab;
    Animator tigerAni;
    Transform tigerPos;
    bool isMoving = false;
    Vector2 startPosition;
    Vector2 targetPosition;
    float moveTime;
    bool goingToTarget = true;

    private Transform tigerTransform;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject tigerObj = GameObject.Find("tiger");
        tigerAni = tigerObj.GetComponent<Animator>();
        tigerPos = tigerObj.GetComponent<Transform>();

        tigerTransform = GameObject.Find("tiger").GetComponent<Transform>();

        startPosition = tigerTransform.position;
        targetPosition = startPosition + new Vector2(0f, 5f);


        moveTime = 0;


        tigerAni.SetTrigger("blue");
        Copy();

        StartCoroutine(StartWait());
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(0.8f);
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            moveTime += Time.deltaTime;
            float t = moveTime / 0.5f;
            t = Mathf.Clamp01(t);

            if (goingToTarget)
                tigerPos.transform.position = Vector2.Lerp(startPosition, targetPosition, t);
            else
                tigerPos.transform.position = Vector2.Lerp(targetPosition, startPosition, t);

            if (t >= 1f)
{
                if (goingToTarget)
                {
                    tigerPos.transform.position = (Vector3)targetPosition;
                    StartCoroutine(WaitAndReturn());
                }
                else
                {
                    tigerPos.transform.position = (Vector3)startPosition;
                    Destroy(gameObject);
                }

                isMoving = false;
            }
        }
    }

    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(1f);
        goingToTarget = false;
        moveTime = 0f;
        isMoving = true;
    }
    

    void Copy(){

for(int i = -2; i < 3; i++)
{
    Vector3 spawnPos = transform.position;
    spawnPos.x += 2.7f * i; 

    StartCoroutine(SpawnWithWarning(spawnPos));

}

}
    IEnumerator SpawnWithWarning(Vector3 pos)
{
    GameObject canvas = GameObject.Find("Canvas");
    GameObject warningCopy = Instantiate(warningBlueUIPrefab, canvas.transform);
    warningCopy.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x * 100, 0);

    yield return new WaitForSeconds(0.7f);
    Destroy(warningCopy);

    Instantiate(enemyBluePrefab, pos, Quaternion.identity);
    
}
}