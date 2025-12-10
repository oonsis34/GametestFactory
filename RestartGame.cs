using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneRestarter : MonoBehaviour
{

    public void RestartCurrentScene()
    {
        Time.timeScale = 1f; 
        
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
