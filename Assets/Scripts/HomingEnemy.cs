using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    public Transform target;
    public float homingSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward*homingSpeed*Time.deltaTime);
    }
}
