using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherCockController : MonoBehaviour
{
    public GameObject cock;

    public WindController wind;

    void Update()
    {
        float amplitude = wind.force * 2.3f;
        cock.transform.localScale = new Vector3(amplitude, 0.3f, 1);
        cock.transform.localPosition = new Vector3(amplitude / 2, 0, 0);
    }
}
