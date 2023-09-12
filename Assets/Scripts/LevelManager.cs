using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public PauseScript pause;
    public Animator fadeScreen;
    
    public Animator quitHover;
    public float transitionTime = 1f;
   
    public int levelScore;
    public float scoretoBeat;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponent<PauseScript>();
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<Animator>();
        gm = GameObject.Find("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeLevel()
    {
        pause.paused = false;
        fadeScreen.SetTrigger("FadeOut");
        StartCoroutine(LoadLevel());
        SceneManager.LoadScene("Menu");
    }

    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void ResetHighScore()
    {
        gm.ResetHighScore();
    }

    public void QuitHoverOn()
    {
        quitHover.SetBool("QuitHover", true);
    }

    public void QuitHoverOff()
    {
        quitHover.SetBool("QuitHover", false);
    }

    
}
