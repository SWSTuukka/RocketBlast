using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missilescript : MonoBehaviour
{
    public GameObject missilePrefab;        
    public Transform playerTransform;       
    public float missileSpeed = 10f;        
    public float shootInterval = 6f;        
    public Transform[] missileHousings;     

    private float shootTimer = 0f;


    private void Update()
    {
        
        shootTimer += Time.deltaTime;

        //This tracks the interval the missiles are launched
        if (shootTimer >= shootInterval)
        {
            ShootMissile();
            shootTimer = 0f; 
        }
    }

    private void ShootMissile()
    {
        foreach (Transform housing in missileHousings)
        {
            //This instantiates a missile prefab from the missile housing
            GameObject missile = Instantiate(missilePrefab, housing.position, housing.rotation);

            //This finds the player's current location in and compares it to the housing location
            Vector3 direction = (playerTransform.position - housing.position).normalized;

            //This makes the missile rigid, so it can damage the player
            Rigidbody missileRigidbody = missile.GetComponent<Rigidbody>();

            //This moves the missile towars the player
            missileRigidbody.velocity = direction * missileSpeed;
        }
    }

   
}
