using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    public GameObject clonePrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Destroy(gameObject);

          
            GameObject clone = Instantiate(clonePrefab, transform.position, Quaternion.identity);

         
            Destroy(clone, 0.4f);
        }
    }
}
