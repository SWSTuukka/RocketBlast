using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BossBattle : MonoBehaviour
{
    public float health = 500f;
 
    public GameObject sparks;
    public GameObject explosion;

    public TextMeshProUGUI healthText;
    public float fadeDuration = 1.5f;

    private bool isBossDefeated = false;
    public string nextLevelName = "Level2";

    private void Start()
    {
        GameObject BossCollision = gameObject;
       
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
            if (!isBossDefeated)
            {
                isBossDefeated = true;
                LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
                if (levelLoader != null)
                {
                    levelLoader.StartNextLevelCoroutine();
                }
                else
                {
                    Debug.LogError("LevelLoader not found in the scene!");
                }

            }
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
        Instantiate(explosion, transform.position, transform.rotation);
        gameObject.SetActive(false);

    }

  
}

