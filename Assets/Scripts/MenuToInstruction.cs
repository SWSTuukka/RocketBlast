using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToInstruction : MonoBehaviour
{
    


    public void LoadScene(string howto)
    {

        SceneManager.LoadScene(howto);
    }

    
}
