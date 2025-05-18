using UnityEngine;

public class enemyMover : MonoBehaviour
{
    // 빨간색 중앙 (음파)
    // 노란색 맵 좌측으로 사라짐(좌측 깨물기)
    // 초록색 맵 우측으로 사라짐(손공격)
    // 파란색 맵 상단으로 사라짐(손톱)
    // 맵 양측(꼬리)

    public float speedX = 2f;
    public float speedY = 2f;

    void Update()
    {
        LeverMove();
    }

    public void LeverMove() // 맵 양측(꼬리) 레버
    {
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        if (transform.position.y > 2.5)
        {
            speedY = -2f;

        }

         if (transform.position.y < 1)
            {
                speedY = 2f;
            }
    }
    
}
