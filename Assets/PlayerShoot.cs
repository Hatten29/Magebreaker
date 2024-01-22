using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float shootCooldown = 0.125f; // Cooldown in seconds

    private float nextShootTime = 0f;

    void Update()
    {
        if (Input.GetKey("j") && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + 1f / shootCooldown;
        }
    }

    void Shoot()
    {
        // Instantiate a projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Access the Rigidbody2D component and set its velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Determine the direction based on player's facing
        Vector2 shootDirection = Vector2.zero;

        if (Input.GetKey("w"))
            shootDirection = Vector2.up;
        else if (Input.GetKey("s"))
            shootDirection = Vector2.down;
        else if (Input.GetKey("a"))
            shootDirection = Vector2.left;
        else if (Input.GetKey("d"))
            shootDirection = Vector2.right;

        rb.velocity = shootDirection * projectileSpeed;
    }
}
