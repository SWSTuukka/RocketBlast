using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour
{
    
    public void LoadScene(string MainGame)
    {
        SceneManager.LoadScene(MainGame);
    }
}
