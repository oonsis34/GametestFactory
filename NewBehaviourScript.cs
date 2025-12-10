using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    
    [Header("Movement Settings")]
    [Tooltip("ความเร็วในการวิ่งไปด้านข้าง")]
    public float moveSpeed = 5f;        

  
    [Header("Ground Positions")]
    [Tooltip("ตำแหน่งอ้างอิงของพื้นต่ำ")]
    public Transform lowGroundAnchor;    
    [Tooltip("ตำแหน่งอ้างอิงของพื้นสูง")]
    public Transform highGroundAnchor;   

    private bool isOnLowGround = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on PlayerMovement object.");
        }
    }

    void Update()
    {
        
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || 
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            ToggleGroundLevel(); 
        }
    }

    void ToggleGroundLevel()
    {
       
        isOnLowGround = !isOnLowGround;

        if (isOnLowGround)
        {
           
            rb.position = new Vector2(transform.position.x, lowGroundAnchor.position.y);
            
            
            rb.gravityScale = 1;

          
            transform.rotation = Quaternion.identity; // ใช้ Quaternion.identity แทน Quaternion.Euler(0, 0, 0)
        }
        else
        {
           
            rb.position = new Vector2(transform.position.x, highGroundAnchor.position.y);

            
            rb.gravityScale = -1;

        
            transform.rotation = Quaternion.Euler(180, 0, 0);
        }
    }
}
