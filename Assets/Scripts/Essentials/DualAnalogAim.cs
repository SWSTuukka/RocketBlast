using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualAnalogAim : MonoBehaviour
{

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gunDirection = Vector3.right * Input.GetAxis("HorizontalRStick") + Vector3.up * Input.GetAxis("VerticalRstick");
        
        if(gunDirection.sqrMagnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(gunDirection, Vector3.back);

            if(player.canFire)
            {
                player.StartCoroutine("Shoot");
            }
            
        }
        
    }
}
