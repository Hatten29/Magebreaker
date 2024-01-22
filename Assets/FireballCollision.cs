using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    public GameObject clonePrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the fireball collides with something tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the fireball upon collision
            Destroy(gameObject);

            // Instantiate the clone at the fireball's position
            GameObject clone = Instantiate(clonePrefab, transform.position, Quaternion.identity);

            // Destroy the clone after 4 seconds
            Destroy(clone, 0.4f);
        }
    }
}
