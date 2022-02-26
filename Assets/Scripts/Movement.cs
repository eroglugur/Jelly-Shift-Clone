using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public static float speed;
    public static float speedLimit;

    public RaycastHit hit1;
    public RaycastHit hit2;
    public LayerMask obstacleMask;
    public LayerMask groundMask;

    public GameObject[] planes;

    private void Start()
    {
        speed = 750f;
        speedLimit = 1050f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.levelFinished && GameManager.isGameActive)
        {
            GameManager.isGameStarted = true;
            rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
        }
        
         transform.localPosition = new Vector3(GetFreezePosition(), transform.position.y, transform.position.z);
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

    public float GetFreezePosition()
    {
        float value = 0;

        if (Physics.Raycast(transform.position, Vector3.down, out hit2, Mathf.Infinity, groundMask))
        {
            if (transform.rotation.y == 0)
            {
                value = hit2.collider.gameObject.transform.position.x;
            }
            else
            {
                value = hit2.collider.gameObject.transform.position.x;
            }
        }

        return value;
    }
}