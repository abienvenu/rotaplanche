using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool hasContact;
    public AudioSource rollAudio;
    public AudioSource hitAudio;
    public Rigidbody rb;
    public WindController wind;
    public GameController game;

    void Start()
    {
      if (game.difficulty == 1) {
        rb.angularDrag = 5;
      } else if (game.difficulty == 2) {
        rb.angularDrag = 2;
      } else {
        rb.angularDrag = 0;
      }
    }

    void Update()
    {
        float minVelocity = 0.01f;

        float velocity = rb.velocity.magnitude;
        if (velocity > minVelocity && hasContact)
        {
            rollAudio.pitch = Mathf.Clamp(0.8f + velocity / 10, 0.4f, 1.8f);
            rollAudio.volume = Mathf.Clamp(velocity * velocity / 5, 0.0f, 1.0f);
            if (!rollAudio.isPlaying)
            {
                rollAudio.Play();
            }
        }
        else if (rollAudio.isPlaying)
        {
            rollAudio.Stop();
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(wind.force * 1.2f, 0, 0));
    }

    void OnCollisionEnter(Collision collision)
    {
        hasContact = true;
        hitAudio.volume = Mathf.Clamp(collision.relativeVelocity.magnitude / 10, 0, 1);
        hitAudio.Play();
    }

    void OnCollisionExit()
    {
        hasContact = false;
    }
}
