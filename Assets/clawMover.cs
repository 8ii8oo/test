using UnityEngine;

using System.Collections;
public class clawMover : MonoBehaviour

//blue

{
    
    public GameObject warningBlueUIPrefab;
    public GameObject enemyBluePrefab;
    Animator tigerAni;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject tigerObj = GameObject.Find("tiger");
        tigerAni = tigerObj.GetComponent<Animator>();
        tigerAni.SetTrigger("blue");
        Copy();
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
            

