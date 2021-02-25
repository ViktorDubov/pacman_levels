using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityStandardAssets.CrossPlatformInput;


public class PacmanMove : MonoBehaviour
{ 
    public float score;
    public GameObject ScoreObject;
    Text scoreText;

    void Start()
    {        
        score = -1f;
        ScoreObject = (transform.Find("Interface").gameObject).transform.Find("Score").gameObject;//GameObject.FindGameObjectWithTag("scoreobject");
        scoreText = ScoreObject.GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();        
    }

    void Update()
    {        
        
    }


    public GameObject gameover;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "dot")
        {
            score = score + 1f;
            //Debug.Log(score);
            scoreText.text = "Score: " + score.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            //Time.timeScale = 0f;
            //GameObject gameoverEnemy = Instantiate(gameover, transform);
            PlayerPrefs.DeleteKey("counterlevel");
            PlayerPrefs.DeleteKey("sizeoflevel");
            //StartCoroutine(Wait(10.0f));            
        }
    }

    //private IEnumerator Wait(float seconds)
    //{        
    //    yield return new WaitForSecondsRealtime(5f); 
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("menu"); 
    //}
}