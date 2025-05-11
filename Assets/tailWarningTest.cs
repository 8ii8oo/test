using UnityEngine;

public class tailWarningTest : MonoBehaviour
{
 private void Awake()
{
     GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
}
}
