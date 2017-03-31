using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHitsTheFloorHard : MonoBehaviour
{
    public Text Points;
    public AudioSource PlayerExplosion;
    public AudioSource EngineSound;
    public GameObject player;
    public GameObject ship;
    public GameObject Lives3;
    public GameObject Lives2;
    public GameObject Lives1;
    public GameObject playerSmoke;
    public GameObject playerSmokeGray;
    public GameObject playerSmokeBlack;
    public GameObject playerSmokeBlackBlack;
    private float curHealth;
    private GameObject healthbar;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            EngineSound.pitch = 0.9f;
            PlayerExplosion.Play();
            ship.GetComponent<Transform>().position = new Vector2(-5.27f, -4.27f);
            var rotationVector = player.transform.rotation.eulerAngles;
            rotationVector.z = 12.107f;
            player.transform.rotation = Quaternion.Euler(rotationVector);
            player.GetComponent<Transform>().position = new Vector3(-5.594f, -3.958f);
            HealthLose();
            playerSmoke.SetActive(true);
            playerSmokeGray.SetActive(false);
            playerSmokeBlack.SetActive(false);
            playerSmokeBlackBlack.SetActive(false);
        }
    }
    void HealthLose()
    {
        healthbar = GameObject.Find("Player").GetComponent<HealthBarHard>().healthbar;
        Vector3 Coords = new Vector3(1f, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
        if (Lives3.activeSelf)
        {
            GameObject.Find("Player").GetComponent<HealthBarHard>().curHealth = 100f;
            healthbar.transform.localScale = Coords;
            Lives3.SetActive(false);
            Lives2.SetActive(true);
        }
        else if (Lives2.activeSelf)
        {
            GameObject.Find("Player").GetComponent<HealthBarHard>().curHealth = 100f;
            healthbar.transform.localScale = Coords;
            Lives2.SetActive(false);
            Lives1.SetActive(true);
        }
        else if (Lives1.activeSelf)
        {
            GameObject.Find("Player").GetComponent<HealthBarHard>().curHealth = 100f;
            healthbar.transform.localScale = Coords;
            Lives1.SetActive(false);
        }
        else if (Lives1.activeSelf == false)
        {
            PointsCalculate();
            StartCoroutine("SceneLoad");
        }
    }
    void PointsCalculate()
    {
        var Score = Convert.ToInt32(Points.text);
        PlayerPrefs.SetInt("ScoreHard", Score);
        var ScoreEasyTop = PlayerPrefs.GetInt("ScoreHardTop");
        if (Score > ScoreEasyTop)
        {
            PlayerPrefs.SetInt("ScoreHardTop", Score);
        }
        PlayerPrefs.Save();
    }

    IEnumerator SceneLoad()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("HighScoreScene", LoadSceneMode.Single);
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
