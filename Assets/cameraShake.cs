using UnityEngine;
using System.Collections;

public class cameraShake : MonoBehaviour
{
   public IEnumerator Shake(float duration, float magnitude)
   {
    Vector3 originalPos = transform.localPosition;
    float elapsed = 0.0f;
    while(elapsed < duration)
    {
        float x = Random.Range(-0.5f, 0.5f) * magnitude;
        float y = Random.Range(-0.3f, 0.3f) * magnitude;

        transform.localPosition = new Vector3(x, y, originalPos.z);
        
        elapsed += Time.deltaTime;

        yield return null;

    }
    transform.localPosition = originalPos;
   }
}
