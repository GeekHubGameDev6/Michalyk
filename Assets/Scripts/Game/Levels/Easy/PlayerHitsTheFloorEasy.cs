#region

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

public class PlayerHitsTheFloorEasy : MonoBehaviour
{
    private float curHealth;
    public AudioSource EngineSound;
    private GameObject healthbar;
    public GameObject Lives1;
    public GameObject Lives2;
    public GameObject Lives3;
    public GameObject player;
    public AudioSource PlayerExplosion;
    public GameObject playerSmoke;
    public GameObject playerSmokeBlack;
    public GameObject playerSmokeBlackBlack;
    public GameObject playerSmokeGray;
    public Text Points;

    public GameObject ship;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D coll)
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
            Debug.Log("Player killed himself");
            HealthLose();
            playerSmoke.SetActive(true);
            playerSmokeGray.SetActive(false);
            playerSmokeBlack.SetActive(false);
            playerSmokeBlackBlack.SetActive(false);
        }
    }

    private void HealthLose()
    {
        healthbar = GameObject.Find("Player").GetComponent<HealthBarEasy>().healthbar;
        var Coords = new Vector3(1f, healthbar.transform.localScale.y, healthbar.transform.localScale.z);

        if (Lives3.activeSelf)
        {
            GameObject.Find("Player").GetComponent<HealthBarEasy>().curHealth = 100f;
            healthbar.transform.localScale = Coords;
            Lives3.SetActive(false);
            Lives2.SetActive(true);
        }
        else if (Lives2.activeSelf)
        {
            GameObject.Find("Player").GetComponent<HealthBarEasy>().curHealth = 100f;
            healthbar.transform.localScale = Coords;
            Lives2.SetActive(false);
            Lives1.SetActive(true);
        }
        else if (Lives1.activeSelf)
        {
            GameObject.Find("Player").GetComponent<HealthBarEasy>().curHealth = 100f;
            healthbar.transform.localScale = Coords;
            Lives1.SetActive(false);
        }
        else if (Lives1.activeSelf == false)
        {
            PointsCalculate();
            StartCoroutine("SceneLoad");
            //Debug.Log("Game Over");
        }
    }

    private void PointsCalculate()
    {
        var Score = Convert.ToInt32(Points.text);
        PlayerPrefs.SetInt("ScoreEasy", Score);
        var ScoreEasyTop = PlayerPrefs.GetInt("ScoreEasyTop");

        if (Score > ScoreEasyTop)
            PlayerPrefs.SetInt("ScoreEasyTop", Score);
        PlayerPrefs.Save();
    }

    private IEnumerator SceneLoad()
    {
        var ao = SceneManager.LoadSceneAsync("HighScoreScene", LoadSceneMode.Single);

        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
                ao.allowSceneActivation = true;

            yield return null;
        }
    }
}