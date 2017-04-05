#region

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

public class MainMenuSelector : MonoBehaviour
{
    public AudioSource Click;
    public Button HighscoresButton;
    public GameObject LevelSelection;
    public GameObject MainMenu;
    public AudioSource Sound;
    public Button StartGameButton;

    private void Start()
    {
        HighscoresButton.onClick.AddListener(HighScoresLoad);
        StartGameButton.onClick.AddListener(GoToSelectLevel);
    }

    private void GoToSelectLevel()
    {
        Click.Play();
        LevelSelection.SetActive(true);
        MainMenu.SetActive(false);
    }

    private void HighScoresLoad()
    {
        Click.Play();
        Sound.Stop();
        StartCoroutine("GoToHighScores");
    }

    private IEnumerator GoToHighScores()
    {
        var AO = SceneManager.LoadSceneAsync("HighScoreScene", LoadSceneMode.Additive);
        while (AO.progress < 0.9f)
        {
            AO.allowSceneActivation = false;
            yield return null;
        }
        AO.allowSceneActivation = true;
    }
}