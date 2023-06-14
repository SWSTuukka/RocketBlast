using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition2 : MonoBehaviour
{
    public Animator fadeScreen;
    public float transitionTime = 3f;
    public string bossLevel; // Set the next scene name in the Inspector

    public void TransitionToNextScene()
    {
        fadeScreen.SetTrigger("FadeOut");
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("BossLevel2");
    }
}
