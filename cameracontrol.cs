using UnityEngine;
using Cinemachine;
using System.Collections;


public class GameStartCameraSequence : MonoBehaviour
{
    [Header("Cinemachine References")]
    public CinemachineVirtualCamera camForPlayer; 
    public CinemachineVirtualCamera camForEnemy;  
    
    [Header("Sequence Settings")]
    [Tooltip("ระยะเวลาที่กล้องโฟกัส Enemy ก่อนเริ่มเกม (วินาที)")]
    public float enemyFocusDuration = 3f; /

    [Header("Script References (For Enabling/Disabling)")]
    public EnemyChase enemyAI;
    public PlayerMovement playerMovement;

    void Start()
    {
       
        StartCoroutine(SwitchToEnemyFocusAndStartGame());
    }

    IEnumerator SwitchToEnemyFocusAndStartGame()
    {
       
        DisableScripts(false); // false คือการปิด
        
       
        camForPlayer.Priority = 0;
        camForEnemy.Priority = 10; // ใช้ค่า Priority ที่สูงกว่า 1 เพื่อให้แน่ใจว่ามันทำงาน

      
        yield return new WaitForSeconds(enemyFocusDuration);

       
        camForPlayer.Priority = 10;
        camForEnemy.Priority = 0;

        
        DisableScripts(true); // true คือการเปิด
    }
    
    void DisableScripts(bool enable)
    {
        if (enemyAI != null)
        {
            enemyAI.enabled = enable;
        }
        if (playerMovement != null)
        {
            playerMovement.enabled = enable;
        }
    }
}
