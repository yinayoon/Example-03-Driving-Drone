using UnityEngine;

public class GenerateRandomNumCoin : MonoBehaviour
{
    [Header("- Int")]
    public int numberOfCoins = 10; // ������ ������ ����

    [Header ("- GameObject")]
    public GameObject coinPrefab; // ������ ���� ������

    [Header("- Collider")]
    public BoxCollider spawnArea; // ������ ������ BoxCollider ����    

    // Private
    private GameObject coinGroup; // CoinGroup ������Ʈ ����

    void Start()
    {
        GenerateCoins();
    }

    void GenerateCoins()
    {
        
        if (coinGroup == null) { coinGroup = new GameObject("@CoinGroup"); } // "CoinGroup"�̶�� �̸��� �� GameObject ����

        for (int i = 0; i < numberOfCoins; i++)
        {            
            Vector3 randomPosition = GetRandomPositionInBox(spawnArea); // BoxCollider�� ũ�� �� ��ġ�� �������� ���� ��ġ ���           
            GameObject newCoin = Instantiate(coinPrefab, randomPosition, Quaternion.identity); // ���� ����            
            newCoin.transform.SetParent(coinGroup.transform); // ������ ������ CoinGroup�� �ڽ����� ����
        }
    }

    Vector3 GetRandomPositionInBox(BoxCollider box)
    {
        // BoxCollider�� �߽� �� ũ�⸦ �������� ���� ��ġ ���
        Vector3 boxCenter = box.transform.position + box.center;
        Vector3 boxSize = box.size;

        float randomX = Random.Range(boxCenter.x - boxSize.x / 2, boxCenter.x + boxSize.x / 2);
        float randomY = Random.Range(boxCenter.y - boxSize.y / 2, boxCenter.y + boxSize.y / 2);
        float randomZ = Random.Range(boxCenter.z - boxSize.z / 2, boxCenter.z + boxSize.z / 2);

        return new Vector3(randomX, randomY, randomZ);
    }
}