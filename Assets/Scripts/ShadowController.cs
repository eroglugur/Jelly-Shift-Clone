using UnityEngine;

public class ShadowController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject distanceShadow;

    private PlayerScaleController playerScaleController;

    private Movement playerMovement;
    private MeshRenderer mRenderer;

    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();

        playerMovement = FindObjectOfType<Movement>();
        playerScaleController = FindObjectOfType<PlayerScaleController>();

        SetDestination();
    }

    private void FixedUpdate()
    {
        if (playerMovement.IsObjectInFront())
        {
            SetDestination();
            mRenderer.enabled = true;
            
            if (playerScaleController.IsGrounded())
            {
                distanceShadow.gameObject.SetActive(true);
            }
            else
            {
                distanceShadow.gameObject.SetActive(false);
            }
        }
        else
        {
            mRenderer.enabled = false;
            distanceShadow.gameObject.SetActive(false);
        }
    }

    public void SetDestination()
    {
        transform.position = playerMovement.hit1.collider.gameObject.transform.position;
        transform.localScale = player.transform.localScale;
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        transform.rotation = player.transform.rotation;
    }
}