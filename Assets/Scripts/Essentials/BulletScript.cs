using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 100f;
    public GameObject splatter;
    public GameManager gm;
    public AudioSource splat;
    public AudioSource pop;
    public int damage = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();
        splat = GameObject.Find("splat").GetComponent<AudioSource>();
        pop = GameObject.Find("pop").GetComponent<AudioSource>();
        Destroy(gameObject, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*bulletSpeed*Time.deltaTime);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            pop.Play();         
            Instantiate(splatter, transform.position, Quaternion.Euler(90,Random.Range(0,360),0));
            Destroy(other.gameObject);
            Destroy(gameObject);
            splat.Play();
            gm.AddScore(damage);
        }
        if (other.gameObject.CompareTag("bomb"))
        {
            bombhealth bomb = other.gameObject.GetComponent<bombhealth>();
            if (bomb != null)
            {
                bomb.TakeDamage((int)damage);
            }
            
            Destroy(gameObject);
        }
    }
    
}
