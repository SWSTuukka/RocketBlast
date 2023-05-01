using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public PauseScript pause;
    public Animator fadeScreen;
    public Animator buttonHover;
    public Animator quitHover;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponent<PauseScript>();
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<Animator>();
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
        SceneManager.LoadScene("MainGame");
    }

    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MainGame");
    }

    public void HoverOn()
    {
        buttonHover.SetBool("Hover",true);
    }

    public void HoverOff()
    {
        buttonHover.SetBool("Hover", false);
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
