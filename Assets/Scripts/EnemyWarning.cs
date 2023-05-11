using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWarning : MonoBehaviour
{
    public Image redEdgeImage;
    public AudioSource audioSource;
    public Animator cameraAnim1;


    // Start is called before the first frame update

    private void Start()
    {
        redEdgeImage.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            redEdgeImage.enabled = true;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            cameraAnim1.SetTrigger("Shake");
        }
       

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            redEdgeImage.enabled = false;
            
        }
        
    }

}