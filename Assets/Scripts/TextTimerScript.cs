﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextTimerScript : MonoBehaviour
{
    public Text timerLabel;
    private float time = 0;
    private int fontSize;
    private float deadline = 15;
    // Start is called before the first frame update
    void Start()
    {
        fontSize = timerLabel.fontSize;
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;

        var minutes = time / 60;
        var seconds = time % 60;
        var fraction = (time * 100) % 100;

        //update the label value
        if (time >= 20)
            SceneManager.LoadScene("DedMenu");
        else
            timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, 20 - seconds, 100 - fraction);

        if (time > deadline && time < 20) 
        {
            timerLabel.color = new Color(1, 0, 0, Abs(Sin(Pow(time, 3) / 6)));
            timerLabel.fontSize = fontSize + (int)Max(0, seconds - deadline); 
        }
    }
}
