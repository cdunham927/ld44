using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBackground : MonoBehaviour
{
    Camera cam;
    public Color nextColor;
    public float lerpSpd;
    float timer = 0;

    private void Awake()
    {
        cam = Camera.main;
        GetNewColors();
    }

    private void Update()
    {
        cam.backgroundColor = Color.Lerp(cam.backgroundColor, nextColor, Time.deltaTime * lerpSpd);

        if (timer <= 0) GetNewColors();

        if (timer > 0) timer -= Time.deltaTime;
    }

    void GetNewColors()
    {
        nextColor = Random.ColorHSV();
        timer = 5f;
    }
}
