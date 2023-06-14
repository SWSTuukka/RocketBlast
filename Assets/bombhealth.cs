using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombhealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject bulletPrefab;
    public GameObject sparks;
    public GameObject explosion;

    private void Start()
    {
        GameObject BombCollision = gameObject;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        // Add explosion logic here
        // For example, play explosion particle effect, deal damage to nearby objects, etc.
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == bulletPrefab)
        {
            {
                TakeDamage(1);
            }

        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript bullet = collision.gameObject.GetComponent<BulletScript>();
            if (bullet != null)
            {
                Instantiate(sparks, collision.transform.position, Quaternion.Euler(0, 180, 0));
                Destroy(collision.gameObject);
                
            }
            GameObject BombCollision = gameObject;

        }

    }
}

