using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSelector : MonoBehaviour {

    public GameObject LevelSelection;
    public GameObject MainMenu;

    public Button StartGameButton;
    public Button HighscoresButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartGameButton.onClick.AddListener(GoToSelectLevel);
        HighscoresButton.onClick.AddListener(GoToHighScores);
    }

    void GoToSelectLevel()
    {
        LevelSelection.SetActive(true);
        MainMenu.SetActive(false);
    }

    void GoToHighScores()
    {
        SceneManager.LoadScene("HighScoreScene");
    }
}
