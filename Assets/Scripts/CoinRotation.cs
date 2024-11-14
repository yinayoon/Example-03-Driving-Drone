using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [Header("- Float")]
    public float rotationSpeed = 50f; // 회전 속도

    void Update()
    {        
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); // Y축을 중심으로 회전
    }
}