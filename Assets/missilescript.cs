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
        // Update the shoot timer
        shootTimer += Time.deltaTime;

        // If enough time has passed, shoot a missile
        if (shootTimer >= shootInterval)
        {
            ShootMissile();
            shootTimer = 0f; // Reset the timer
        }
    }

    private void ShootMissile()
    {
        foreach (Transform housing in missileHousings)
        {
            // Instantiate a missile prefab at the housing's position
            GameObject missile = Instantiate(missilePrefab, housing.position, housing.rotation);

            // Calculate the direction towards the player
            Vector3 direction = (playerTransform.position - housing.position).normalized;

            // Get the missile's Rigidbody component
            Rigidbody missileRigidbody = missile.GetComponent<Rigidbody>();

            // Apply force to the missile to make it move towards the player
            missileRigidbody.velocity = direction * missileSpeed;
        }
    }

   
}
