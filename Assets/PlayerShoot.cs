using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireballPrefab;
    public GameObject clonePrefab;

    public float fireCooldown = 1.5f;
    private float nextFireTime;

    void Update()
    {
        // Check for player input to shoot with cooldown
        if (Input.GetKeyDown(KeyCode.J) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        // Determine the direction the player is facing
        Vector2 shootDirection = Vector2.zero; // Default direction (standing still)

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            shootDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            shootDirection = Vector2.right;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            shootDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            shootDirection = Vector2.down;
        }

        // Instantiate the fireball at the player's position with rotation
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

        // Set the velocity of the fireball based on the shoot direction
        fireball.GetComponent<Rigidbody2D>().velocity = shootDirection.normalized * 10f;

        // Attach a script to the fireball to handle collision and cloning
        FireballCollision fireballCollisionScript = fireball.AddComponent<FireballCollision>();
        fireballCollisionScript.clonePrefab = clonePrefab;

        // Destroy the fireball after 4 seconds
        Destroy(fireball, 4f);
    }
}
