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

    public Animator fadeScreen;
    public float transitionTime = 1f;

    public static GameManager gameManager;

    // Start is called before the first frame update
    public void StartGame()
    {
        fadeScreen.SetTrigger("FadeOut");
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

        if (score > hiScore)
        {
            hiScore = score;
            hiScoreText.text = "Hi Score: " + hiScore.ToString();
            PlayerPrefs.SetInt("HiScore", hiScore);
            PlayerPrefs.Save();
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
