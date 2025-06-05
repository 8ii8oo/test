using UnityEngine;

using System.Collections;
public class clawMover : MonoBehaviour

//blue

{

    public GameObject warningBlueUIPrefab;
    public GameObject enemyBluePrefab;
    Animator tigerAni;
    Transform tigerPos;

    Vector2 startPosition;
    Vector2 targetPosition;
    float moveTime;


    private Transform tigerTransform;






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        Copy();

        StartCoroutine(StartWait());
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(0.8f);

    }

    void Update()
    {

    }



    void Copy(){

for(int i = -2; i < 3; i++)
{
    Vector3 spawnPos = enemyBluePrefab.transform.position;
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
