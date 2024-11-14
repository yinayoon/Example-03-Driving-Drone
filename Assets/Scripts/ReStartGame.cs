using UnityEngine;
using UnityEngine.SceneManagement; // Scene 관리에 필요한 네임스페이스 추가

public class ReStartGame : MonoBehaviour
{
    void Update()
    {
        // 스페이스바 입력 감지
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Time.timeScale = 1f; // Time.timeScale 초기화 (게임 정지 상태 해제)
            PlayerController.CoinCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 활성화된 Scene 다시 로드
        }
    }
}