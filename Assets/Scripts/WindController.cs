using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public float force = 0.0f;
    private float timer = 0.0f;
    private bool isChanging = false;
    private float oldForce = 0.0f;
    private float targetForce = 0.0f;
    private float targetTimer;

    public GameController game;
    public AudioSource windSound;

    // Start is called before the first frame update
    void Start()
    {
        targetTimer = Random.Range(0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= targetTimer)
        {
            newTimerWindow();
        }
        if (isChanging)
        {
            force = oldForce + timer / targetTimer * (targetForce - oldForce);
        }
        windSound.volume = Mathf.Abs(force / 4);
        windSound.pitch = 0.4f + Mathf.Abs(force / 1.5f);
    }

    private void newTimerWindow()
    {
        timer = 0;

        float difficulty = (float)game.difficulty;
        targetTimer = Random.Range(3.0f, 12.0f) / difficulty;
        isChanging = !isChanging;
        if (isChanging)
        {
            oldForce = force;
            targetForce = Random.Range(-difficulty, difficulty);
        }
    }
}
