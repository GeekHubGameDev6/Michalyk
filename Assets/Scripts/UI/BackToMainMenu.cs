using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    public AudioSource Sound;
    public Button BackButton;
    // Use this for initialization
    void Start()
    {
        Sound.Play();
        BackButton.onClick.AddListener(Load);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Load()
    {
        Sound.Stop();
        StartCoroutine("LoadMenu");
    }
    IEnumerator LoadMenu()
    {
        AsyncOperation AO = SceneManager.LoadSceneAsync("MainMenuScene", LoadSceneMode.Single);
        
        while (AO.progress < 0.9f)
        {
            AO.allowSceneActivation = false;
            yield return null;
        }
        AO.allowSceneActivation = true;
    }
}
