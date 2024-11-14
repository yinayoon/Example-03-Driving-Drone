using UnityEngine;
using TMPro; // TextMeshPro 사용을 위한 네임스페이스 추가

public class GameManager : MonoBehaviour
{
    [Header("- Float")]
    public float gameDuration = 60f; // 게임 지속 시간 (초)

    [Header("- GameObject")]
    public GameObject gameOverObject; // "Game Over"를 표시할 GUI GameObject
    public GameObject player; // 플레이어 오브젝트

    [Header("- GUI")]
    public TextMeshProUGUI timerText; // 타이머를 표시할 TextMeshProUGUI
    public TextMeshProUGUI finalCoinText; // 최종 획득 코인 수를 표시할 TextMeshProUGUI    

    // Private
    private bool isGameOver = false; // 게임 종료 상태 플래그
    private float remainingTime; // 남은 시간

    void Start()
    {
        remainingTime = gameDuration; // 남은 시간을 게임 지속 시간으로 초기화

        // 초기 UI 설정
        if (timerText != null) { UpdateTimerUI(); } // 초기 타이머 UI 업데이트
        if (gameOverObject != null) { gameOverObject.SetActive(false); } // 게임 시작 시 GameOver 오브젝트 비활성화
        if (finalCoinText != null) { finalCoinText.gameObject.SetActive(false); } // 게임 시작 시 최종 코인 텍스트 비활성화
    }

    void Update()
    {
        if (isGameOver) return; // 게임이 종료된 상태에서는 업데이트 중지
                
        remainingTime -= Time.deltaTime; // 남은 시간 감소
        if (remainingTime <= 0)
        {
            remainingTime = 0; // 남은 시간이 음수가 되지 않도록 설정
            EndGame(); // 게임 종료
        }
                
        UpdateTimerUI(); // 타이머 UI 업데이트
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            // 시간을 "MM:SS" 형식으로 표시
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    void EndGame()
    {
        isGameOver = true; // 게임 종료 상태 설정
                
        if (gameOverObject != null) { gameOverObject.SetActive(true); } // "Game Over" GUI 오브젝트 활성화

        if (finalCoinText != null) // 최종 코인 텍스트 활성화 및 업데이트
        {
            finalCoinText.gameObject.SetActive(true);
            finalCoinText.text = $"Coins Collected : {PlayerController.CoinCount}";
        }

        if (player != null) // 플레이어 동작 멈추기
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.enabled = false; // PlayerController 비활성화
                StopPlayerSound(playerController); // 이동 소리 멈춤
            }
        }

        // 모든 물리 동작 멈추기
        Time.timeScale = 0f; // 게임 전체 정지
    }

    void StopPlayerSound(PlayerController playerController) // 이동 소리 중지 메소드
    {        
        AudioSource playerAudio = playerController.GetComponent<AudioSource>(); 
        if (playerAudio != null && playerAudio.isPlaying)
            playerAudio.Stop(); // 이동 소리 멈춤
    }
}