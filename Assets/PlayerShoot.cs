using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireballPrefab;
    public GameObject clonePrefab;

    public float fireCooldown = 1.5f;
    private float nextFireTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        Vector2 shootDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            shootDirection += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            shootDirection += Vector2.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            shootDirection += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            shootDirection += Vector2.down;
        }

        shootDirection.Normalize();

        if (shootDirection != Vector2.zero)
        {
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            fireball.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f)); 

            fireball.GetComponent<Rigidbody2D>().velocity = shootDirection * 10f;

            FireballCollision fireballCollisionScript = fireball.AddComponent<FireballCollision>();
            fireballCollisionScript.clonePrefab = clonePrefab;

            Destroy(fireball, 4f);
        }
    }


}
