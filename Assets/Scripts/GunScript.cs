using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition =
        new Vector3(target.position.x, this.transform.position.y, target.position.z);
        
        transform.LookAt(targetPosition);   
    }
}
