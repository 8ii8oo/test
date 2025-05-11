using UnityEngine;

public class testSpawner : MonoBehaviour
{
public GameObject enemyBluePrefab;
public GameObject[] warningPanels;

    void Start()
    {
        Attack();
    } 
    void Attack()
    {
        warningPanels[0].SetActive(true);
        Invoke("WarningAttack", 1.5f);
    } 

    void WarningAttack()
    {
        warningPanels[0].SetActive(false);
        Instantiate(enemyBluePrefab, new Vector3(0, -1, 0), Quaternion.identity);

    }
}
