using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game Mode")]
    public bool dualanalog = false;
    public bool mouseaim = false;

    public int score;
    public static int hiScore = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    public Animator scoreAnimation;
    public GameObject alien;

    public GameObject[] enemySpawner;
    public GameObject player;

    public Animator fadeScreen;
    public float transitionTime = 1f;
    public Animator camerarotate;

    public static GameManager gameManager;
    public SceneTransition sceneTransition;
    public int requiredPoints = 10;


    void Start()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }

        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    public void StartGame()
    {
        fadeScreen.SetTrigger("FadeOut");
        camerarotate.SetTrigger("camerarotate");
        StartCoroutine(LoadLevel());
        SceneManager.LoadScene("howto");

    }

    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("howto");

    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        if(scoreAnimation == null)
        {
            scoreAnimation = GameObject.Find("Score").GetComponent<Animator>();
            scoreAnimation.SetTrigger("score");
        }
        else
        {
            scoreAnimation.SetTrigger("score");
        }

        if(alien == null)
        {
            alien = GameObject.Find("points");
            alien.GetComponent<AlphaFade>().fade = true;
        }
        else
        {
            alien.GetComponent<AlphaFade>().fade = true;
        }

        //if (score > hiScore)
        {
           // hiScore = score;
            //hiScoreText.text = "Hi Score: " + hiScore.ToString();
            //PlayerPrefs.SetInt("HiScore", hiScore);
            //PlayerPrefs.Save();
        }

        if (score >= requiredPoints)
        {
            sceneTransition.TransitionToNextScene();
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
