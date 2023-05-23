using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    private AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.pitch = Random.Range(0.85f, 1.10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
