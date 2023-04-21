using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float camdelay = 0.2f;

    public GameObject ui;
    public GameObject[] postEffects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This is for tracking the player avatar on screen
        transform.position = Vector3.Lerp(transform.position, target.position, camdelay * Time.deltaTime);
    }
}
