using UnityEngine;

public class PlayerMovingScope : MonoBehaviour
{
    [Header("- Collider")]
    public Collider boundaryCollider; // �÷��̾��� �̵��� ������ Box Collider

    // Private
    private Bounds boundaryBounds; // Box Collider�� ���

    void Start()
    {
        boundaryBounds = boundaryCollider.bounds; // Box Collider�� ��踦 ������
    }

    void Update()
    {
        RestrictMovement();
    }

    void RestrictMovement()
    {
        if (boundaryCollider == null) return;        
        Vector3 currentPosition = transform.position; // ���� �÷��̾��� ��ġ

        // ��� ������ ���ѵ� ��ġ ���
        float clampedX = Mathf.Clamp(currentPosition.x, boundaryBounds.min.x, boundaryBounds.max.x);
        float clampedY = Mathf.Clamp(currentPosition.y, boundaryBounds.min.y, boundaryBounds.max.y);
        float clampedZ = Mathf.Clamp(currentPosition.z, boundaryBounds.min.z, boundaryBounds.max.z);
                
        transform.position = new Vector3(clampedX, clampedY, clampedZ); // ���ѵ� ��ġ�� �÷��̾��� ��ġ�� ����
    }
}