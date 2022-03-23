using System;
using UnityEngine;
using DG.Tweening;
using Vector3 = UnityEngine.Vector3;

public class PlayerCollisionController : MonoBehaviour
{
    public GameObject virtualCamera;
    
    private ShadowController shadowController;
    private UIController uiController;
    private Rigidbody rigidbody;

    public static bool objectIsColliding;
    public static bool turned = false;
    
    private float turnX;

    [SerializeField] private LayerMask ground;
    private RaycastHit hit;


    private void Awake()
    {
        DOTween.Init();
    }

    private void Start()
    {
        virtualCamera.gameObject.SetActive(true);
        shadowController = FindObjectOfType<ShadowController>();
        uiController = FindObjectOfType<UIController>();
        rigidbody = GetComponent<Rigidbody>();
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

            StartCoroutine(uiController.SetNextLevelScreen());
        }

        if (other.gameObject.CompareTag("TurnLeft"))
        {
            transform.DORotate(
                new Vector3(transform.localRotation.x, transform.localRotation.y - 90, transform.localRotation.z), 0f,
                RotateMode.WorldAxisAdd);

            transform.localPosition = new Vector3(turnX, transform.localScale.y / 2, transform.position.z);
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
        }

        if (other.gameObject.CompareTag("TurnRight"))
        {
            transform.DORotate(
                new Vector3(transform.localRotation.x, transform.localRotation.y + 90, transform.localRotation.z), 0f,
                RotateMode.WorldAxisAdd);

            transform.localPosition = new Vector3(turnX, transform.localScale.y / 2, transform.position.z);
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        }

        if (other.gameObject.CompareTag("Fall"))
        {
            virtualCamera.gameObject.SetActive(false);
            GameManager.isGameActive = false;
            
            StartCoroutine(uiController.SetRestartScreen());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle")) 
        {
            objectIsColliding = true;

            if (Mathf.Round(transform.rotation.y) == 0)
            {
                transform.DOMoveZ(transform.position.z - 3, 1);
            }
            else
            {
                transform.DOMoveX(transform.position.x - 3, 1);
            }
            
            
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            turnX = other.gameObject.transform.position.x;
        }
    }
}