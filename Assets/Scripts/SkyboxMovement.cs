using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxMovement : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        RenderSettings.skybox.SetFloat("_Rotation", offset);
    }
}

