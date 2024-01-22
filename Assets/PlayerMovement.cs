using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Get input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontal, vertical);

        // Normalize to prevent faster movement diagonally
        movement.Normalize();

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
