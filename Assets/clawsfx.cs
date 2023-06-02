using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clawsfx : MonoBehaviour
{

    public GameObject sparks2;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(sparks2, collision.transform.position, Quaternion.Euler(0, 180, 0));
            Destroy(collision.gameObject);
        }


    }
}
