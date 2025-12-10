using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    public Transform playerReference; 
    public TextMeshProUGUI scoreTextNormal; 
    public TextMeshProUGUI scoreTextPro; 

    [Header("Score Settings")]
    [Tooltip("ตัวคูณคะแนนต่อวินาที")]
    public float scoreMultiplier = 1f;
    [Tooltip("ระยะเวลา Cooldown ก่อนเริ่มนับคะแนน (วินาที)")]
    public float scoreStartCooldown = 10f; 

    private float currentScore = 0f; 
    private float cooldownTimer = 0f; 
    private bool isCooldownOver = false;

    void Update()
    {
        
        if (!isCooldownOver)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= scoreStartCooldown)
            {
                isCooldownOver = true;
            }
        }
       
        else
        {
            
            if (playerReference != null)
            {
                currentScore += Time.deltaTime * scoreMultiplier;
                
             
                int displayScore = Mathf.FloorToInt(currentScore);
                string scoreString = "Score: " + displayScore.ToString();
                
                if (scoreTextNormal != null)
                {
                    scoreTextNormal.text = scoreString;
                }
                if (scoreTextPro != null)
                {
                    scoreTextPro.text = scoreString;
                }
            }
        }
    }
}
