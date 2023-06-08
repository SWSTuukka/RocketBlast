using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public GameObject bomb;

    public float spawnTimer = 3;

    // Start is called before the first frame update
    void Start()
    {

        //Instantiate(enemy, transform.position, transform.rotation);
        //Use the line Invoke to get objects spawning randomly
        Invoke("Spawn", 3);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        Instantiate(bomb, transform.position, transform.rotation);
        spawnTimer = Random.Range(3, 7);
        Invoke("Spawn", spawnTimer);
    }
}
