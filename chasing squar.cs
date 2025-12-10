using UnityEngine;


public class BoundaryTrigger : MonoBehaviour
{
    public GameObject gameOverUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Game Over: Player hit Boundary Trigger.");
            TriggerGameOver();
        }
    }

    void TriggerGameOver() 
    {
    
        Time.timeScale = 0f;
        
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); 
        }
    }
}
