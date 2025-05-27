using UnityEngine;

using System.Collections;
public class clawMover : MonoBehaviour

//blue

{
    
    public GameObject warningBlueUIPrefab;
    public GameObject enemyBluePrefab;
    Animator tigerAni;
    Vector3 target = new Vector3(0f, 5f, 0f);
    Transform tigerPos; 
    bool isMoving;
    Vector2 startPosition;
    Vector2 targetPosition;
    float moveTime;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject tigerObj = GameObject.Find("tiger");
        tigerAni = tigerObj.GetComponent<Animator>();
        tigerPos = tigerObj.GetComponent<Transform>();
        
        
        tigerAni.SetTrigger("blue");
        Copy();
    }

    void Update()
    {
        if (isMoving == false)
        {
            startPosition = (Vector2)tigerPos.transform.position;
            targetPosition = (Vector2)(target);
            moveTime = 0;
            isMoving = true;
        }


        if (isMoving)
        {
            moveTime += Time.deltaTime;
            float t = moveTime / 0.5f;

            tigerPos.transform.position = (Vector3)Vector2.Lerp(startPosition, targetPosition, t);

            if (t >= 1f)
            {
                tigerPos.transform.position = (Vector3)targetPosition;
                isMoving = false;

            }
        }


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

    GameObject BlueCopy = Instantiate(enemyBluePrefab, pos, Quaternion.identity);
    Destroy(gameObject);
}
}