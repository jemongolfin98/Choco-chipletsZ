using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    public Text livesText;
    public Text winText;
    public Text scoreText;
    public Text loseText;
    public Text gameOverText;
    public Text restartText;
    public Text nextLevelText;

    private Rigidbody2D rb2d;
    private int score;
    private int lives;
    private bool gameOver;
    private bool restart;
    private bool nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        restartText.text = "";
        gameOverText.text = "";
        nextLevelText.text = "";
        SetScoreText();
        SetLivesText();
        gameOver = false;
        nextLevel = false;
        restart = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Level 2");
            }

        }

        if (nextLevel)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene("Level 1");
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score = score + 50;
            SetScoreText();

        }

        if (other.gameObject.CompareTag("Pickup1"))
        {
            other.gameObject.SetActive(false);
            score = score + 100;
            SetScoreText();



            if (other.gameObject.CompareTag("Enemy"))
            {
                lives = lives - 1;
                
                if (gameOver == true)
                {
                    other.gameObject.SetActive(false);
                }


            }
        }
     
    }

    void SetScoreText()
    {
        scoreText.text = score.ToString();

        if (score >= 16699)
        {
            winText.text = "Level Complete!";
            GameOver();
            if (gameOver)
            {
                nextLevelText.text = "Press 'L' for Level 1";
                nextLevel = true;

                restartText.text = "Press 'R' for Level Restart";
                restart = true;

               
            }
        }
    }

    void SetLivesText()
    {
        livesText.text = lives.ToString();

        if (lives == 0)
        {
            loseText.text = "Better Luck Next Time!";
            GameOver();
            if (gameOver)
            {
                restartText.text = "Press 'R' for Level Restart";
                restart = true;

               
            }
        }
    }

    public void GameOver()
    {
        if (lives == 0)
        {
            gameOverText.text = "Game Over!";

          
        }

        gameOver = true;
    }
}
