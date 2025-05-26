using UnityEngine;
using System.Collections;

public class TigerPawHitbox : MonoBehaviour
{
    // Paw foot

    
    public GameObject tigerPaw;

 
    Animator tigerAni;
    GameObject footGreenPrefab;
    public GameObject WarningBoxPrefab;
    private GameObject warningBoxInstance;
    public Transform canvasTransform;
    void Start()
    {
       GameObject warningBox = Instantiate(WarningBoxPrefab, canvasTransform);
        GameObject tigerObj = GameObject.Find("tiger");
        tigerAni = tigerObj.GetComponent<Animator>();
        tigerAni.SetTrigger("green");

         StartCoroutine(ShowWarningAndAttack());
    }



    IEnumerator ShowWarningAndAttack()
    {
        
         yield return new WaitForSeconds(0.5f);
        if (warningBoxInstance != null)
        {
            Destroy(warningBoxInstance);
        }

        Instantiate(footGreenPrefab, transform.position, Quaternion.identity);


    
    }
}