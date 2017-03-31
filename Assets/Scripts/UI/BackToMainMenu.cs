using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    public AudioSource Sound;
    public Button BackButton;
    void Start()
    {
        Sound.Play();
        BackButton.onClick.AddListener(Load);
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
