#region

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

public class BackToMainMenu : MonoBehaviour
{
    public Button BackButton;
    public AudioSource Sound;

    private void Start()
    {
        Sound.Play();
        BackButton.onClick.AddListener(Load);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                Sound.Stop();
                StartCoroutine("LoadMenu");
            }
            else
            {
                Sound.Stop();
                StartCoroutine("LoadMenu");
            }
        }
    }

    private void Load()
    {
        Sound.Stop();
        StartCoroutine("LoadMenu");
    }

    private IEnumerator LoadMenu()
    {
        var AO = SceneManager.LoadSceneAsync("MainMenuScene", LoadSceneMode.Single);
        while (AO.progress < 0.9f)
        {
            AO.allowSceneActivation = false;
            yield return null;
        }
        AO.allowSceneActivation = true;
    }
}