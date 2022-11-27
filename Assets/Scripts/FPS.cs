using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{

   [SerializeField] int samples = 100;
    [SerializeField] TextMeshProUGUI fpsText;


    int count;
    float totalTime;



    public void Start()
    {
        count = samples;
        totalTime = 0f;
        Application.targetFrameRate = 60;
    }

    public void Update()
    {
        count -= 1;
        totalTime += Time.deltaTime;

        if (count == 0)
        {
            float fps = samples / totalTime;
            fpsText.text = "fps " + fps.ToString("F0");

            totalTime = 0f;
            count = samples;
        }
    }



}
