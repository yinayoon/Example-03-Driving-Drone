using UnityEngine;
using UnityEngine.SceneManagement; // Scene ������ �ʿ��� ���ӽ����̽� �߰�

public class ReStartGame : MonoBehaviour
{
    void Update()
    {
        // �����̽��� �Է� ����
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Time.timeScale = 1f; // Time.timeScale �ʱ�ȭ (���� ���� ���� ����)
            PlayerController.CoinCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� Ȱ��ȭ�� Scene �ٽ� �ε�
        }
    }
}