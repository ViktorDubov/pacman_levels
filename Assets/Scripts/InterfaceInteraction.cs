using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceInteraction : MonoBehaviour
{
    //public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    
    void Start()
    {
        //GameIsPause = false;
    }
    
    public void pressPause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPause = true;
    }
}
