using UnityEngine;

public class CameraDontDestroy : MonoBehaviour
{
    private static CameraDontDestroy instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }
}
