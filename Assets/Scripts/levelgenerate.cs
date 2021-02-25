using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelgenerate : MonoBehaviour
{
    List<GameObject[,]> currentlevel = new List<GameObject[,]>();
    public GameObject gamewinEnemy;

    void Start()
    {
        winscreen.SetActive(false);
        losescreen.SetActive(false);
        pausescreen.SetActive(false);
        currentlevel.Add(generateNewLevel());
        gamewinEnemy.SetActive(false);
        empty.transform.position = new Vector3(0f, 0f, 0f);
    }

    //float maxscore;
    public GameObject winscreen;
    public GameObject losescreen;
    public GameObject pausescreen;
    public bool pacmanisdestroyed = false;

    //public Button pauseBotton;
    void FixedUpdate()
    {
        //Debug.Log(currentlevel[0][1, 1].GetComponent<PacmanMove>().score);
        //Debug.Log(player_one.GetComponent<PacmanMove>().score>2*sizeoflevel);
        if (currentlevel[0][1, 1] == null)
        {
            pacmanisdestroyed = true;
            loadlosescreen();
        }
        else
        {
            if (currentlevel[0][1, 1].GetComponent<PacmanMove>().score > 3 * sizeoflevel)
            {
                //Debug.Log("startnewlevel");
                loadwinscreen();
            }
        }
    }

    public void pressPauseBotton()
    {
        pausescreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void continueGame()
    {
        pausescreen.SetActive(false);
        Time.timeScale = 1f;
    }
        
    
    public void loadlosescreen()
    {
        losescreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void playAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("level1");
    }

    public void loadwinscreen()
    {
        winscreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void nextLevel()
    {
        currentlevel.Add(generateNewLevel());//создали новый уровень
        for (int i = 0; i < sizeoflevel-4; i++)
        {
            for (int j = 0; j < sizeoflevel - 4; j++)
            {
                if (currentlevel[0][i,j]!=null)
                {
                    Destroy(currentlevel[0][i, j]);
                }
            }
        }
        currentlevel.RemoveAt(0);
        winscreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void saveGame()
    {
        PlayerPrefs.SetInt("counterlevel", counterlevel);
        PlayerPrefs.SetInt("sizeoflevel", sizeoflevel);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public int sizeoflevel=12;
    public int counterlevel = 1;    

    //public PacmanMove player;
    //public PacmanDirection playerdirection;
    public GameObject player_one;
    public GameObject squre;
    public GameObject pacdot;
    public GameObject enemy;
    public GameObject empty;
    
    GameObject[,] generateNewLevel()
    {
        if (PlayerPrefs.HasKey("sizeoflevel"))
        {
            sizeoflevel = PlayerPrefs.GetInt("sizeoflevel");
            counterlevel = PlayerPrefs.GetInt("counterlevel");
        }
        GameObject[,] generatedmassive = new GameObject[sizeoflevel, sizeoflevel];

        float probabilityofenemy = (float)counterlevel/((float)sizeoflevel * (float)sizeoflevel);
        float probabilityofsqure = 2 / (float)sizeoflevel;
        
        float rndnumber;

        for (int i = 0; i < sizeoflevel; i++)
        {
            for (int j = 0; j < sizeoflevel; j++)
            {                
                                
                if (i==0 || i==sizeoflevel-1 || j == 0 || j == sizeoflevel - 1)// граничные блоки
                {
                    generatedmassive[i, j] = Instantiate(squre, empty.transform);
                    generatedmassive[i, j].transform.position = new Vector3(empty.transform.position.x + 1+2 * i, empty.transform.position.x + 1+2 * j, 0);
                    //break;
                }
                else
                {
                    if (i == 1 && j == 1)//расположение игрока
                    {
                        generatedmassive[i, j] = Instantiate(player_one, empty.transform);
                        
                        generatedmassive[i, j].transform.position = new Vector3(empty.transform.position.x + 1 + 2 * i, empty.transform.position.x + 1 + 2 * j, 0);
                                                
                    }
                    else
                    {
                        rndnumber = Random.Range(0f, 100f) / 100f;
                        if (rndnumber <= probabilityofsqure)//установка квадрата
                        {
                            generatedmassive[i, j] = Instantiate(squre, empty.transform);
                            generatedmassive[i, j].transform.position = new Vector3(empty.transform.position.x + 1 + 2 * i, empty.transform.position.x + 1 + 2 * j, 0);
                            //break;
                        }
                        else
                        {
                            generatedmassive[i, j] = Instantiate(pacdot, empty.transform);
                            generatedmassive[i, j].transform.position = new Vector3(empty.transform.position.x + 1 + 2 * i, empty.transform.position.x + 1 + 2 * j, 0);
                            if (rndnumber > probabilityofsqure && rndnumber <= probabilityofsqure + probabilityofenemy)//установка врага
                            {
                                generatedmassive[i, j] = Instantiate(enemy, empty.transform);
                                generatedmassive[i, j].transform.position = new Vector3(empty.transform.position.x + 1 + 2 * i, empty.transform.position.x + 1 + 2 * j, 0);
                                //break;
                            }
                        }                        
                    }
                } 
            }
        }
        counterlevel += 1;
        sizeoflevel += 2;

        PlayerPrefs.SetInt("counterlevel", counterlevel);
        PlayerPrefs.SetInt("sizeoflevel", sizeoflevel);
        return generatedmassive;
    }
}
