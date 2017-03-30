using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public GameObject LevelSelection;
    public GameObject MainMenu;
    public Button ReturnButton;
    public Button EasyLevel;
    public Button MediumLevel;
    public Button HardLevel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ReturnButton.onClick.AddListener(ReturnToMenu);
        EasyLevel.onClick.AddListener(LoadEasyLevel);
        MediumLevel.onClick.AddListener(LoadMediumLevel);
        HardLevel.onClick.AddListener(LoadHardLevel);
    }
    void LoadEasyLevel()
    {
        SceneManager.LoadScene("GameEasy");
    }
    void LoadMediumLevel()
    {
        SceneManager.LoadScene("GameMedium");
    }
    void LoadHardLevel()
    {
        SceneManager.LoadScene("GameHard");
    }
    void ReturnToMenu()
    {
        MainMenu.SetActive(true);
        LevelSelection.SetActive(false);
    }
}
