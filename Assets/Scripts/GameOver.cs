using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text textScore;


    void Start()
    {
        textScore.text = "Score: " + PlayerPrefs.GetString("score");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
