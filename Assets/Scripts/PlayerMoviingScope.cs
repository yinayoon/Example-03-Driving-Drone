using UnityEngine;

public class PlayerMovingScope : MonoBehaviour
{
    [Header("- Collider")]
    public Collider boundaryCollider; // 플레이어의 이동을 제한할 Box Collider

    // Private
    private Bounds boundaryBounds; // Box Collider의 경계

    void Start()
    {
        boundaryBounds = boundaryCollider.bounds; // Box Collider의 경계를 가져옴
    }

    void Update()
    {
        RestrictMovement();
    }

    void RestrictMovement()
    {
        if (boundaryCollider == null) return;        
        Vector3 currentPosition = transform.position; // 현재 플레이어의 위치

        // 경계 내에서 제한된 위치 계산
        float clampedX = Mathf.Clamp(currentPosition.x, boundaryBounds.min.x, boundaryBounds.max.x);
        float clampedY = Mathf.Clamp(currentPosition.y, boundaryBounds.min.y, boundaryBounds.max.y);
        float clampedZ = Mathf.Clamp(currentPosition.z, boundaryBounds.min.z, boundaryBounds.max.z);
                
        transform.position = new Vector3(clampedX, clampedY, clampedZ); // 제한된 위치를 플레이어의 위치로 적용
    }
}