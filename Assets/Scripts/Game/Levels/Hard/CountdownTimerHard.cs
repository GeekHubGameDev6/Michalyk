﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimerHard : MonoBehaviour {

    // Use this for initialization
    public float timeLeft = 10.0f;

    public Text TimerText;

    public Text Points;

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
                PointsCalculate();
                Loader();
            }
        }
    }

    void PointsCalculate()
    {
        var Score = Convert.ToInt32(Points.text);
        PlayerPrefs.SetInt("ScoreHard", Score);
        var ScoreHardTop = PlayerPrefs.GetInt("ScoreHardTop");

        if (Score > ScoreHardTop)
        {
            PlayerPrefs.SetInt("ScoreHardTop", Score);
        }
        PlayerPrefs.Save();
    }

    void Loader()
    {
        StartCoroutine("SceneLoad");
    }

    IEnumerator SceneLoad()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("HighScoreScene", LoadSceneMode.Single);

        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}