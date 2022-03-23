using UnityEngine;
public class PlayerScaleController : MonoBehaviour
{

    private Touch touch; // input
    private float scaleChangeSpeed = 0.5f;
    private float touchSwipeSensitivity = 10;

    private void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float swipeRange = Mathf.Clamp(touch.deltaPosition.y / touchSwipeSensitivity, -1f, 1f);
                float scaleFactor = Mathf.Pow(2f, swipeRange * scaleChangeSpeed);

                float newX = Mathf.Clamp(transform.localScale.x / scaleFactor, 0.25f, 2f);
                float newY = Mathf.Clamp(transform.localScale.y * scaleFactor, 0.25f, 2f);

                transform.localScale = new Vector3(newX, newY, 1);
                
                if (Movement.isGrounded)
                {
                    transform.position = new Vector3(transform.position.x, newY / 2, transform.position.z);
                }
            }
        }
    }

}