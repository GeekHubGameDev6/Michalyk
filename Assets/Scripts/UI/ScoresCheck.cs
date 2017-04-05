#region

using UnityEngine;
using UnityEngine.UI;

#endregion

public class ScoresCheck : MonoBehaviour
{
    public Text EasyTopScore;
    public Text EasyYourScore;
    public Text HardTopScore;
    public Text HardYourScore;
    public Text MediumTopScore;
    public Text MediumYourScore;

    private void Start()
    {
        Check();
    }

    private void Check()
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