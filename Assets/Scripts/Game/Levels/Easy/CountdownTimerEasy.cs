using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimerEasy : MonoBehaviour
{
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
        PlayerPrefs.SetInt("ScoreEasy", Score);
        var ScoreEasyTop = PlayerPrefs.GetInt("ScoreEasyTop");

        if (Score > ScoreEasyTop)
        {
            PlayerPrefs.SetInt("ScoreEasyTop", Score);
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