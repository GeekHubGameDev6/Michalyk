using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {




    // Use this for initialization
    public float timeLeft = 10.0f;

    public Text TimerText;

    private bool flag = true;

    void Update()
    {
        if (flag)
        {
            timeLeft -= Time.deltaTime;
            TimerText.text = Mathf.Round(timeLeft).ToString();

            if (timeLeft <= 0)
            {
                flag = false;
                PlayerPrefs.SetInt("Score", Convert.ToInt32(TimerText.text));
            }
        }
    }
}