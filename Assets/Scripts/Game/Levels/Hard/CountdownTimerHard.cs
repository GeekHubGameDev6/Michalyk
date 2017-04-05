#region

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

public class CountdownTimerHard : MonoBehaviour
{
    private bool flag = true;
    public Text Points;
    public float timeLeft = 10.0f;
    public Text TimerText;

    private void Update()
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

    private void PointsCalculate()
    {
        var Score = Convert.ToInt32(Points.text);
        PlayerPrefs.SetInt("ScoreHard", Score);
        var ScoreHardTop = PlayerPrefs.GetInt("ScoreHardTop");

        if (Score > ScoreHardTop)
            PlayerPrefs.SetInt("ScoreHardTop", Score);
        PlayerPrefs.Save();
    }

    private void Loader()
    {
        StartCoroutine("SceneLoad");
    }

    private IEnumerator SceneLoad()
    {
        var ao = SceneManager.LoadSceneAsync("HighScoreScene", LoadSceneMode.Single);

        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
                ao.allowSceneActivation = true;

            yield return null;
        }
    }
}