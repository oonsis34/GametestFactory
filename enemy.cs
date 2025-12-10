using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class EnemyChase : MonoBehaviour
{
    [Header("Target and Movement")]
    public Transform playerTarget; 
    [Tooltip("ความเร็วในการไล่ตาม Player")]
    public float speed = 2f;
    
    [Header("Game Over Settings")]
    public GameObject gameOverUI; 
    public Button restartButton; 

  
    private float originalSpeed; 
    private bool isGameOver = false; 

[SerializeField] InterstitialAdExample interstitialAdExample; 

    void Start()
    {
        originalSpeed = speed;
        if (restartButton != null)
        {
           
            restartButton.onClick.AddListener(() => StartCoroutine(RestartGameSequence()));
        }
        else
        {
            Debug.LogWarning("Restart Button not assigned in EnemyChase script.");
        }
    }

    void Update()
    {
       
        if (isGameOver || playerTarget == null) return;

       
        Vector2 direction = (playerTarget.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HandleGameOver();
        }
    }

   
    void HandleGameOver() // เปลี่ยนชื่อจาก GameOver เพื่อความชัดเจนในการเรียกใช้
    {
        
        if (isGameOver) return;

        Debug.Log("Game Over: Player hit by Enemy");
        isGameOver = true; 
        speed = 0; 
        
       
        Time.timeScale = 0f; 

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // แสดง Game Over UI
        }
    }

    
    public IEnumerator RestartGameSequence() 
    {
       
        Debug.Log("Initiating Revive/Restart Sequence...");

        
        Time.timeScale = 1f; 

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false); // ซ่อน Game Over UI
        }
        
       
        speed = 0.2f;
        Debug.Log("Enemy speed temporarily reduced to 0.2f.");

      
        yield return new WaitForSecondsRealtime(5f); 

      
        speed = originalSpeed;
        Debug.Log($"Enemy speed restored to {originalSpeed}f.");

       
        isGameOver = false; 
    }
}
