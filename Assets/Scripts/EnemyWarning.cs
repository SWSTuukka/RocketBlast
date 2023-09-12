using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWarning : MonoBehaviour
{
    public Image redEdgeImage;
    public Animator cameraAnim1;


    // Start is called before the first frame update

    private void Start()
    {
        redEdgeImage.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) //If conditions are met, the player receives a warning about an enemy
        {
            redEdgeImage.enabled = true;
            cameraAnim1.SetTrigger("Shake");
            StartCoroutine("RedImageFade");
        }
       

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) //Conditions met, this disables the warning
        {
            redEdgeImage.enabled = false;
            
        }
        
    }

    public IEnumerator RedImageFade()
    {
        yield return new WaitForSeconds(0.5f);
        redEdgeImage.enabled = false;
    }


}