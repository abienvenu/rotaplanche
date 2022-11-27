using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanckController : MonoBehaviour
{
    public GameController game;

    void Update()
    {
        float rotationSpeed = -10.0f * game.difficulty;
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * horizontalInput * rotationSpeed * Time.deltaTime);

        float width = transform.localScale.x;
        width *= Mathf.Pow(1.0f - (float)game.difficulty / 100, Time.deltaTime);
        transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);
    }
}
