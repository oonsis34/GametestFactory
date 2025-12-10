using UnityEngine;
using TMPro;


public class CoinDisplay : MonoBehaviour
{
    [Tooltip("Text component สำหรับแสดงจำนวนเหรียญ")]
    public TextMeshProUGUI coinTextUI; // เปลี่ยนชื่อจาก coinText

    private void Update()
    {
       
        if (CoinManager.Instance != null && coinTextUI != null)
        {
            
            coinTextUI.text = CoinManager.Instance.Coins.ToString(); 
        }
    }
}
