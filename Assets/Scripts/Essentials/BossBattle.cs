using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public float health = 1f;
 
    public GameObject sparks;

    private void Start()
    {
        GameObject BossCollision = gameObject;
        DontDestroyOnLoad(BossCollision);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript bullet = collision.gameObject.GetComponent<BulletScript>();
            if (bullet != null)
            {
                float bulletDamage = bullet.damage;
                TakeDamage(bulletDamage);
            }
            GameObject BossCollision = gameObject;
            DontDestroyOnLoad(BossCollision);
           
            Instantiate(sparks, collision.transform.position, Quaternion.Euler(0,180,0));
            Destroy(collision.gameObject);
            
        }
    }

    void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Play death animation, disable boss object, etc.
        gameObject.SetActive(false);
    }
}

