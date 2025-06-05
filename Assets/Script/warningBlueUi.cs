using UnityEngine;

public class warningBlueUi : MonoBehaviour
{
    public GameObject enemyBluePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Warning();
    }



    void Warning()
    {
        for(int i = -1; i < 2; i = i++)
        
        transform.position = enemyBluePrefab.transform.position;

    }
}
