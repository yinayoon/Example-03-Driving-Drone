using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [Header("- Float")]
    public float rotationSpeed = 50f; // ȸ�� �ӵ�

    void Update()
    {        
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); // Y���� �߽����� ȸ��
    }
}