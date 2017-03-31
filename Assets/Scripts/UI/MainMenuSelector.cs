using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSelector : MonoBehaviour
{
    public AudioSource Sound;
    public GameObject LevelSelection;
    public GameObject MainMenu;
    public Button StartGameButton;
    public Button HighscoresButton;

    void Start ()
    {
        HighscoresButton.onClick.AddListener(HighScoresLoad);
    }
	void Update () {
        StartGameButton.onClick.AddListener(GoToSelectLevel);
    }
    void GoToSelectLevel()
    {
        LevelSelection.SetActive(true);
        MainMenu.SetActive(false);
    }
    void HighScoresLoad()
    {
        Sound.Stop();
        StartCoroutine("GoToHighScores");
    }
    IEnumerator GoToHighScores()
    {
        AsyncOperation AO = SceneManager.LoadSceneAsync("HighScoreScene", LoadSceneMode.Additive);
        while (AO.progress < 0.9f)
        {
            AO.allowSceneActivation = false;
            yield return null;
        }
        AO.allowSceneActivation = true;
    }
}
