using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;

    public static float speed;
    public static float speedLimit;
    public static bool isGrounded;
    
    public RaycastHit hit1;
    public RaycastHit hit2;
    
    public LayerMask obstacleMask;
    public LayerMask groundMask;

    private void Start()
    {
        GroundCheck();
        speed = 750f;
        speedLimit = 1050f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundCheck();
        if (!GameManager.levelFinished && GameManager.isGameActive)
        {
            GameManager.isGameStarted = true;
            rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
        }
    }
    public bool IsObjectInFront()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit1, Mathf.Infinity,
                obstacleMask))
        {
            if (hit1.collider.gameObject.CompareTag("Obstacle"))
            {
                return true;
            }
        }
        return false;
    }
    
   public void GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit2, 1f,
                groundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
   
}