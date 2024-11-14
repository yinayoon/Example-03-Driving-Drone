using UnityEngine;
using TMPro; // TextMeshPro 사용을 위한 네임스페이스 추가

public class CoinGUI : MonoBehaviour
{
    [Header ("- GUI")]
    public TextMeshProUGUI coinCountText; // UI 텍스트를 담당할 TextMeshProUGUI 컴포넌트

    private void Update()
    {
        coinCountText.text = PlayerController.CoinCount.ToString();
    }
}
