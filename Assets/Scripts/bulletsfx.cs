using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsfx : MonoBehaviour
{
    public GameObject bulletsound;

    // Update is called once per frame
    void Update()
    {
       DontDestroyOnLoad(bulletsound);
    }
}
