using UnityEngine;
using DG.Tweening;
using Vector3 = UnityEngine.Vector3;

public class PlayerCollisionController : MonoBehaviour
{
    public GameObject virtualCamera;

    private Rigidbody rb;
    private ShadowController shadowController;

    public static bool objectIsColliding;

    private void Start()
    {
        virtualCamera.gameObject.SetActive(true);
        rb = GetComponent<Rigidbody>();
        shadowController = FindObjectOfType<ShadowController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            shadowController.SetDestination();
            if (Movement.speed < Movement.speedLimit)
            {
                Movement.speed += 100;
            }
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.levelFinished = true;
        }

        if (other.gameObject.CompareTag("Turn"))
        {
            transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z), 0f,
                RotateMode.WorldAxisAdd);

            transform.localPosition = new Vector3(transform.position.x, transform.position.y, 56.482f);
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }

        if (other.gameObject.CompareTag("Fall"))
        {
            virtualCamera.gameObject.SetActive(false);
            GameManager.isGameActive = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            objectIsColliding = true;
            if (transform.rotation.y == 0)
            {
                transform.DOMoveZ(transform.localPosition.z - 3, 1);
            }
            else
            {
                transform.DOMoveX(transform.localPosition.x - 3, 1);
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        objectIsColliding = false;
    }
}