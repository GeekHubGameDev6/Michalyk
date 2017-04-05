#region

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

public class LevelSelector : MonoBehaviour
{
    public AudioSource Click;
    public Button EasyLevel;
    public Button HardLevel;
    public GameObject LevelSelection;
    public GameObject MainMenu;
    public Button MediumLevel;
    public Button ReturnButton;

    private void Start()
    {
        ReturnButton.onClick.AddListener(ReturnToMenu);
        EasyLevel.onClick.AddListener(LoadEasyLevel);
        MediumLevel.onClick.AddListener(LoadMediumLevel);
        HardLevel.onClick.AddListener(LoadHardLevel);
    }

    private void LoadEasyLevel()
    {
        Click.Play();
        StartCoroutine("EasyLoad");
    }

    private void LoadMediumLevel()
    {
        Click.Play();
        StartCoroutine("MediumLoad");
    }

    private void LoadHardLevel()
    {
        Click.Play();
        StartCoroutine("HardLoad");
    }

    private void ReturnToMenu()
    {
        Click.Play();
        MainMenu.SetActive(true);
        LevelSelection.SetActive(false);
    }

    private IEnumerator EasyLoad()
    {
        var ao = SceneManager.LoadSceneAsync("GameEasy", LoadSceneMode.Single);
        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
                ao.allowSceneActivation = true;
            yield return null;
        }
    }

    private IEnumerator MediumLoad()
    {
        var ao = SceneManager.LoadSceneAsync("GameMedium", LoadSceneMode.Single);
        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
                ao.allowSceneActivation = true;
            yield return null;
        }
    }

    private IEnumerator HardLoad()
    {
        var ao = SceneManager.LoadSceneAsync("GameHard", LoadSceneMode.Single);
        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
                ao.allowSceneActivation = true;
            yield return null;
        }
    }
}