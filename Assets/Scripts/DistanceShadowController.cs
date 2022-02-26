using UnityEngine;

public class DistanceShadowController : MonoBehaviour
{
    [SerializeField] private GameObject mainShadow;
    [SerializeField] private GameObject player;

    private PlayerScaleController playerScaleController;

    private void Start()
    {
        playerScaleController = FindObjectOfType<PlayerScaleController>();
    }

    private void FixedUpdate()
    {
        SetPosition();
        SetScale();
    }

    void SetPosition()
    {
        if (player.transform.rotation.y == 0)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
                player.transform.position.z + transform.localScale.z / 2);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x + transform.localScale.x / 2,
                player.transform.position.y, mainShadow.transform.position.z);
        }
    }

    void SetScale()
    {
        if (player.transform.rotation.y == 0)
        {
            transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y,
                Mathf.Abs(mainShadow.transform.position.z - player.transform.position.z) );
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(mainShadow.transform.position.x - player.transform.position.x),
                player.transform.localScale.y,
                player.transform.localScale.x);
        }
    }
}