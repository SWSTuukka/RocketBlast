using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    [Range (0f, 10f)]
    public float enemySpeed = 10f;
    
    public GameObject retrybutton;
    


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //print("PlayerDead");
            Destroy(other.gameObject);
            Destroy(gameObject);
  

        }
    }

    
}
