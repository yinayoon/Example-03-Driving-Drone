using UnityEngine;
using TMPro; // TextMeshPro ����� ���� ���ӽ����̽� �߰�

public class CoinGUI : MonoBehaviour
{
    [Header ("- GUI")]
    public TextMeshProUGUI coinCountText; // UI �ؽ�Ʈ�� ����� TextMeshProUGUI ������Ʈ

    private void Update()
    {
        coinCountText.text = PlayerController.CoinCount.ToString();
    }
}
