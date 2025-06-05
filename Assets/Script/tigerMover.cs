using UnityEngine;
using System.Collections;

public class TigerMover : MonoBehaviour
{
     Animator tigerAni;
    bool isMoving = false;
    Vector2 startPosition;
    Vector2 targetPosition;
    float moveTime;
    bool goingToTarget = true;

    private Transform tigerTransform;
    GameObject mixMov;
    public bool mixSpawning = true;

    void Start()
    {
        Up();
    }


    void Update()
    {
        UpPos();
    }



    void Up()
    {

        GameObject tigerObj = GameObject.Find("tiger");
        tigerAni = tigerObj.GetComponent<Animator>();

        tigerTransform = GameObject.Find("tiger").GetComponent<Transform>();

        startPosition = tigerTransform.position;
        targetPosition = startPosition + new Vector2(0f, 5f);


        moveTime = 0;

        StartCoroutine(StartWait());
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(0.8f);
        isMoving = true;
    }

    void UpPos()
    {
        
        if (isMoving)
        {
            moveTime += Time.deltaTime;
            float t = moveTime / 0.5f;
            t = Mathf.Clamp01(t);

            if (goingToTarget)
                this.transform.position = Vector2.Lerp(startPosition, targetPosition, t);
            else
                this.transform.position = Vector2.Lerp(targetPosition, startPosition, t);

            if (t >= 1f)
            {
                if (goingToTarget)
                {
                    this.transform.position = (Vector3)targetPosition;
                    StartCoroutine(WaitAndReturn());
                }
                else
                {
                    this.transform.position = (Vector3)startPosition;
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
        mixSpawning = false;
    }
}


