using UnityEngine;

public class GenerateRandomNumCoin : MonoBehaviour
{
    [Header("- Int")]
    public int numberOfCoins = 10; // 생성할 코인의 개수

    [Header ("- GameObject")]
    public GameObject coinPrefab; // 생성할 코인 프리팹

    [Header("- Collider")]
    public BoxCollider spawnArea; // 코인을 생성할 BoxCollider 영역    

    // Private
    private GameObject coinGroup; // CoinGroup 오브젝트 참조

    void Start()
    {
        GenerateCoins();
    }

    void GenerateCoins()
    {
        
        if (coinGroup == null) { coinGroup = new GameObject("@CoinGroup"); } // "CoinGroup"이라는 이름의 빈 GameObject 생성

        for (int i = 0; i < numberOfCoins; i++)
        {            
            Vector3 randomPosition = GetRandomPositionInBox(spawnArea); // BoxCollider의 크기 및 위치를 기준으로 랜덤 위치 계산           
            GameObject newCoin = Instantiate(coinPrefab, randomPosition, Quaternion.identity); // 코인 생성            
            newCoin.transform.SetParent(coinGroup.transform); // 생성된 코인을 CoinGroup의 자식으로 설정
        }
    }

    Vector3 GetRandomPositionInBox(BoxCollider box)
    {
        // BoxCollider의 중심 및 크기를 기준으로 랜덤 위치 계산
        Vector3 boxCenter = box.transform.position + box.center;
        Vector3 boxSize = box.size;

        float randomX = Random.Range(boxCenter.x - boxSize.x / 2, boxCenter.x + boxSize.x / 2);
        float randomY = Random.Range(boxCenter.y - boxSize.y / 2, boxCenter.y + boxSize.y / 2);
        float randomZ = Random.Range(boxCenter.z - boxSize.z / 2, boxCenter.z + boxSize.z / 2);

        return new Vector3(randomX, randomY, randomZ);
    }
}