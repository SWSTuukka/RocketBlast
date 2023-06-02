using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clawsound : MonoBehaviour
{

    public GameObject sparks;

   

    private void Start()
    {
        //GameObject BossCollision = gameObject;

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript bullet = collision.gameObject.GetComponent<BulletScript>();
            if (bullet != null)
            {
                //float bulletDamage = bullet.damage;
                
            }
            //GameObject BossCollision = gameObject;


            Instantiate(sparks, collision.transform.position, Quaternion.Euler(0, 180, 0));
            Destroy(collision.gameObject);

        }
    }
}
