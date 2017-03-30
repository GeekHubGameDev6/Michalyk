using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    public Button BackButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    BackButton.onClick.AddListener(LoadMenu);
	}

    void LoadMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
