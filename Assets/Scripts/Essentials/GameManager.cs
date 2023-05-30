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
    


    public LevelManager levelManager;



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
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scoreText == null)
        {
            scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

        }
        if (sceneTransition == null)
        {
            sceneTransition = GameObject.Find("toboss").GetComponent<SceneTransition>();

        }
        if(hiScoreText == null)
        {
            hiScoreText = GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>();
            hiScoreText.text = "Achieved Shots: " + hiScore.ToString();
        }
        if(levelManager == null)
        {
            levelManager = GameObject.Find("Main Camera").GetComponent<LevelManager>();
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
        levelManager.levelScore += 1;
        scoreText.text = levelManager.levelScore.ToString();
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

        if (score > hiScore)
        {
            hiScore = score;
            hiScoreText.text = "Achieved Shots: " + hiScore.ToString();
            PlayerPrefs.SetInt("Highscore", hiScore);
            PlayerPrefs.Save();
        }

        if (levelManager.levelScore >= levelManager.scoretoBeat)
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
