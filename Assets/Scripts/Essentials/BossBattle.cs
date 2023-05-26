using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossBattle : MonoBehaviour
{
    public float health = 500f;
 
    public GameObject sparks;

    public TextMeshProUGUI healthText;
    public float fadeDuration = 1.5f;

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
        int damage = Mathf.CeilToInt(amount);
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }

        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        healthText.text = Mathf.Max(health, 0).ToString();
        healthText.CrossFadeAlpha(1f, 0f, true);
    }

    void Die()
    {
        // Play death animation, disable boss object, etc.
        gameObject.SetActive(false);
    }
}

