using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public IEnumerator AdvanceToNextLevel()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Level2");
    }
}
