using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiondamage : MonoBehaviour
{
    public GameObject splatter;
    public GameManager gm;
    public AudioSource splat;
    public AudioSource pop;
    public int damage = 1;
    public int damageMultiplier = 1;
    public int damageAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();
        splat = GameObject.Find("splat").GetComponent<AudioSource>();
        pop = GameObject.Find("pop").GetComponent<AudioSource>();
        StartCoroutine("ExplosionOff");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            Instantiate(splatter, other.transform.position, Quaternion.Euler(90, Random.Range(0, 360), 0));
            Destroy(other.gameObject);
            
            damageMultiplier++;
            pop.Play();
            pop.pitch = pop.pitch + 0.1f;
            splat.Play();
            splat.pitch = splat.pitch + 0.1f;
            gm.AddScore(damage*damageMultiplier);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            print("Explode");
            other.GetComponent<PlayerController>().TakeDamage(70);
        }

        if (other.gameObject.CompareTag("bomb"))
        {
            other.GetComponent<bombhealth>().TakeDamage(10);
        }
          
    }
    public IEnumerator ExplosionOff()
    {
        yield return new WaitForSeconds(1);
        pop.pitch = 1.0f;
        splat.pitch = 1.0f;
        Destroy(gameObject);
    }
}
