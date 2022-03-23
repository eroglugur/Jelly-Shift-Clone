using UnityEngine;

public class DistanceShadowController : MonoBehaviour
{
    [SerializeField] private GameObject mainShadow;
    [SerializeField] private GameObject player;

    private MeshRenderer mRenderer;
    private Movement playerMovement;

    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        playerMovement = FindObjectOfType<Movement>();
    }

    private void FixedUpdate()
    {
        if (playerMovement.IsObjectInFront())
        {
            mRenderer.enabled = true;
        }
        else
        {
            mRenderer.enabled = false;
        }


        SetPosition();
        SetScale();
    }

    void SetPosition()
    {
        float positionX = player.transform.position.x + (transform.localScale.x / 2);
        float positionZ = player.transform.position.z + (transform.localScale.z / 2);


        if (Mathf.Round(player.transform.rotation.y) == 0) 
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
                positionZ);
        }
        else
        {
            transform.position = new Vector3(positionX,
                player.transform.position.y, player.transform.position.z);
        }
    }

    void SetScale()
    {
        float localScaleX = Mathf.Abs(player.transform.position.x - mainShadow.transform.position.x);
        float localScaleZ = Mathf.Abs(mainShadow.transform.position.z - player.transform.position.z);

        if  (Mathf.Round(player.transform.rotation.y) == 0) 
        {
            transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y,
                localScaleZ);
        }
        else
        {
            transform.localScale = new Vector3(localScaleX, player.transform.localScale.y,
                player.transform.localScale.x);
        }
    }
}