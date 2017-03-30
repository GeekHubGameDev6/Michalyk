using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresCheck : MonoBehaviour
{

    public Text EasyTopScore;
    public Text EasyYourScore;

    public Text MediumTopScore;
    public Text MediumYourScore;

    public Text HardTopScore;
    public Text HardYourScore;

    // Use this for initialization
    void Start ()
    {
        Check();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Check()
    {
        var ScoreEasy = PlayerPrefs.GetInt("ScoreEasy");

        var ScoreEasyTop = PlayerPrefs.GetInt("ScoreEasyTop");

        var ScoreMedium = PlayerPrefs.GetInt("ScoreMedium");
        var ScoreMediumTop = PlayerPrefs.GetInt("ScoreMediumTop");

        var ScoreHard = PlayerPrefs.GetInt("ScoreHard");
        var ScoreHardTop = PlayerPrefs.GetInt("ScoreHardTop");

        EasyTopScore.text = ScoreEasyTop.ToString();
        EasyYourScore.text = ScoreEasy.ToString();

        MediumTopScore.text = ScoreMediumTop.ToString();
        MediumYourScore.text = ScoreMedium.ToString();

        HardTopScore.text = ScoreHardTop.ToString();
        HardYourScore.text = ScoreHard.ToString();
    }
}
