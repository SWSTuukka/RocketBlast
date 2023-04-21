using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int score;
    public static int hiScore = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;

    public GameObject[] enemySpawner;
    public GameObject player;

    public static GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }

        else if(gameManager != this)
        {
            Destroy(gameObject);
        }

        
    }



    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemyZone()
    {
        int rnd = Random.Range(0, 4);
        Instantiate(enemySpawner[rnd], new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z),
            player.transform.rotation);
    }


}
