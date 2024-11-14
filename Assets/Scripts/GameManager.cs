using UnityEngine;
using TMPro; // TextMeshPro ����� ���� ���ӽ����̽� �߰�

public class GameManager : MonoBehaviour
{
    [Header("- Float")]
    public float gameDuration = 60f; // ���� ���� �ð� (��)

    [Header("- GameObject")]
    public GameObject gameOverObject; // "Game Over"�� ǥ���� GUI GameObject
    public GameObject player; // �÷��̾� ������Ʈ

    [Header("- GUI")]
    public TextMeshProUGUI timerText; // Ÿ�̸Ӹ� ǥ���� TextMeshProUGUI
    public TextMeshProUGUI finalCoinText; // ���� ȹ�� ���� ���� ǥ���� TextMeshProUGUI    

    // Private
    private bool isGameOver = false; // ���� ���� ���� �÷���
    private float remainingTime; // ���� �ð�

    void Start()
    {
        remainingTime = gameDuration; // ���� �ð��� ���� ���� �ð����� �ʱ�ȭ

        // �ʱ� UI ����
        if (timerText != null) { UpdateTimerUI(); } // �ʱ� Ÿ�̸� UI ������Ʈ
        if (gameOverObject != null) { gameOverObject.SetActive(false); } // ���� ���� �� GameOver ������Ʈ ��Ȱ��ȭ
        if (finalCoinText != null) { finalCoinText.gameObject.SetActive(false); } // ���� ���� �� ���� ���� �ؽ�Ʈ ��Ȱ��ȭ
    }

    void Update()
    {
        if (isGameOver) return; // ������ ����� ���¿����� ������Ʈ ����
                
        remainingTime -= Time.deltaTime; // ���� �ð� ����
        if (remainingTime <= 0)
        {
            remainingTime = 0; // ���� �ð��� ������ ���� �ʵ��� ����
            EndGame(); // ���� ����
        }
                
        UpdateTimerUI(); // Ÿ�̸� UI ������Ʈ
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            // �ð��� "MM:SS" �������� ǥ��
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    void EndGame()
    {
        isGameOver = true; // ���� ���� ���� ����
                
        if (gameOverObject != null) { gameOverObject.SetActive(true); } // "Game Over" GUI ������Ʈ Ȱ��ȭ

        if (finalCoinText != null) // ���� ���� �ؽ�Ʈ Ȱ��ȭ �� ������Ʈ
        {
            finalCoinText.gameObject.SetActive(true);
            finalCoinText.text = $"Coins Collected : {PlayerController.CoinCount}";
        }

        if (player != null) // �÷��̾� ���� ���߱�
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.enabled = false; // PlayerController ��Ȱ��ȭ
                StopPlayerSound(playerController); // �̵� �Ҹ� ����
            }
        }

        // ��� ���� ���� ���߱�
        Time.timeScale = 0f; // ���� ��ü ����
    }

    void StopPlayerSound(PlayerController playerController) // �̵� �Ҹ� ���� �޼ҵ�
    {        
        AudioSource playerAudio = playerController.GetComponent<AudioSource>(); 
        if (playerAudio != null && playerAudio.isPlaying)
            playerAudio.Stop(); // �̵� �Ҹ� ����
    }
}