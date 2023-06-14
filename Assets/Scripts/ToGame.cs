using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();
    }

    public void LoadScene(string MainGame)
    {
        SceneManager.LoadScene(MainGame);
    }

    
    

    public void MouseAimSelected()
    {
        gm.mouseaim = true;
        gm.dualanalog = false;
        print("mouseaimselected");

    }

    public void DualAnalogSelected()
    {
        gm.mouseaim = false;
        gm.dualanalog = true;
        print("dualselecetd");
    }
}
