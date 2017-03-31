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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ReturnButton.onClick.AddListener(ReturnToMenu);
        EasyLevel.onClick.AddListener(LoadEasyLevel);
        MediumLevel.onClick.AddListener(LoadMediumLevel);
        HardLevel.onClick.AddListener(LoadHardLevel);
    }

    void LoadEasyLevel()
    {
        StartCoroutine("EasyLoad");
    }

    void LoadMediumLevel()
    {
        StartCoroutine("MediumLoad");
    }

    void LoadHardLevel()
    {
        StartCoroutine("HardLoad");
    }

    void ReturnToMenu()
    {
        MainMenu.SetActive(true);
        LevelSelection.SetActive(false);
    }

    IEnumerator EasyLoad()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("GameEasy", LoadSceneMode.Single);

        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    IEnumerator MediumLoad()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("GameMedium", LoadSceneMode.Single);

        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    IEnumerator HardLoad()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("GameHard", LoadSceneMode.Single);

        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
