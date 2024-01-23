using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if (spriteRenderer == null || animator == null)
        {
            Debug.LogError("SpriteRenderer or Animator component not found on the player!");
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        UpdateAnimatorParameters(horizontal, vertical);

        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        transform.Translate(movement * speed * Time.deltaTime);
    }

    void UpdateAnimatorParameters(float horizontalInput, float verticalInput)
    {
        float inputMagnitude = new Vector2(horizontalInput, verticalInput).magnitude;

        animator.SetBool("walking", inputMagnitude > 0);

        // Set the "walking" parameter to false when there is no movement input
        if (inputMagnitude == 0)
        {
            animator.SetBool("walking", false);
        }
    }
}
