using UnityEngine;
public class ShadowController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Movement playerMovement;
    private MeshRenderer mRenderer;

    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();

        playerMovement = FindObjectOfType<Movement>();

        SetDestination();
    }

    private void FixedUpdate()
    {
        if (playerMovement.IsObjectInFront())
        {
            SetDestination();
            mRenderer.enabled = true;
        }
        else
        {
            mRenderer.enabled = false;
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