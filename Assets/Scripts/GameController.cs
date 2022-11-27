using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public int difficulty;

    public Text textDifficulty;
    public float timer = 0;
    public Text textTimer;
    private float displayDifficultyTimer = 0;

    void Start()
    {
        Cursor.visible = false;
        DisplayDifficulty();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
        {
            difficulty = 1;
            DisplayDifficulty();
        }
        if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
        {
            difficulty = 2;
            DisplayDifficulty();
        }
        if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
        {
            difficulty = 3;
            DisplayDifficulty();       
        }

        if (ball.GetComponent<Rigidbody>().position.y < -8 || Mathf.Abs(ball.GetComponent<Rigidbody>().position.x) > 9)
        {
            GameOver();
        }

        timer += Time.deltaTime;
        textTimer.text = Mathf.Round(timer).ToString();

        if (displayDifficultyTimer > 0)
        {
            textDifficulty.color = new Color(
                textDifficulty.color.r,
                textDifficulty.color.g,
                textDifficulty.color.b,
                displayDifficultyTimer / 3
            );
            displayDifficultyTimer -= Time.deltaTime;
            if (displayDifficultyTimer <= 0) {
                textDifficulty.color = new Color(1, 1, 1, 0);
            }
        }
    }

    void DisplayDifficulty()
    {
        if (difficulty == 1) {
            textDifficulty.color = new Color32(0xA5, 0xD6, 0xB0, 1);
            textDifficulty.text = "Easy";
        } else if (difficulty == 2) {
            textDifficulty.color = new Color32(0xE0, 0xBB, 0x93, 1);
            textDifficulty.text = "Medium";
        } else {
            textDifficulty.color = new Color32(0xE9, 0x95, 0x95, 1);
            textDifficulty.text = "Hard";
        }
        displayDifficultyTimer = 3;
    }

    void GameOver()
    {
        PlayerPrefs.SetString("score", Mathf.Round(timer).ToString());
        timer = 0;
        SceneManager.LoadScene("GameOver");
    }
}
