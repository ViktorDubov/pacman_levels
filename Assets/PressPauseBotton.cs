using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPauseBotton : MonoBehaviour
{
    public GameObject pauseMenu;
    public void pressPauseBotton()
    {
        Debug.Log("pause presses");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
