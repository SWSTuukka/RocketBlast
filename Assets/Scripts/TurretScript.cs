using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform target;
    public GameObject bullet;
    public float rotationSpeed = 5f;
    public Transform gun;
    public Vector3 bulletOffset = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0f;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }

    public void Shoot()
    {
        Vector3 spawnPosition = gun.position + gun.TransformDirection(bulletOffset);
        Instantiate(bullet, gun.position, gun.rotation);
        
    }
}
