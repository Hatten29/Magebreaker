using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the player!");
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

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
}
