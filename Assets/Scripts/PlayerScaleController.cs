using UnityEngine;

public class PlayerScaleController : MonoBehaviour
{

    private Touch touch; // input
    private float scaleChangeSpeed = 0.5f;
    private float touchSwipeSensitivity = 10;

    public LayerMask ground;
    
    private void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && !PlayerCollisionController.objectIsColliding)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float swipeRange = Mathf.Clamp(touch.deltaPosition.y / touchSwipeSensitivity, -1f, 1f);
                float scaleFactor = Mathf.Pow(2f, swipeRange * scaleChangeSpeed);

                float newX = Mathf.Clamp(transform.localScale.x / scaleFactor, 0.25f, 2f);
                float newY = Mathf.Clamp(transform.localScale.y * scaleFactor, 0.25f, 2f);

                transform.localScale = new Vector3(newX, newY, transform.localScale.z);
                if (IsGrounded())
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, newY / 2, transform.localPosition.z);
                }
            }
        }
    }

    public bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1f, ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}