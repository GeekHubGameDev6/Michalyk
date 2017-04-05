#region

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

public class HealthBarMedium : MonoBehaviour
{
    public float curHealth;
    public AudioSource EnemyHitsPlayer;
    public AudioSource EngineSound;
    public float Health = 100f;
    public GameObject healthbar;
    public GameObject Lives1;
    public GameObject Lives2;
    public GameObject Lives3;
    public GameObject LivesBar;
    public GameObject player;
    public GameObject PlayerExplosion;
    public Text Points;
    public GameObject ship;
    public GameObject Smoke;
    public GameObject SmokeBlack;
    public GameObject SmokeBlackBlack;
    public GameObject SmokeGray;

    private void Start()
    {
        EngineSound.PlayDelayed(1f);
        curHealth = Health;
    }

    private void SetHealthBar(float myHealth)
    {
        healthbar.transform.localScale = new Vector3(Mathf.Clamp(myHealth, 0f, 1f), healthbar.transform.localScale.y,
            healthbar.transform.localScale.z);
        if (curHealth == 0)
        {
            healthbar.transform.localScale = new Vector3(1f, healthbar.transform.localScale.y,
                healthbar.transform.localScale.z);
            PlayerKilled();
        }
    }

    public void DecreaseHealth()
    {
        EnemyHitsPlayer.Play();
        curHealth -= 25f;
        var calc_Health = curHealth / Health;
        SetHealthBar(calc_Health);
        HealthLose();
        SmokeColourChange();
    }

    private void PlayerKilled()
    {
        Explosion();
        SmokeColourChange();
        ship.GetComponent<Transform>().position = new Vector2(-5.27f, -4.27f);
        var rotationVector = player.transform.rotation.eulerAngles;
        rotationVector.z = 12.107f;
        player.transform.rotation = Quaternion.Euler(rotationVector);
        player.GetComponent<Transform>().position = new Vector3(-5.594f, -3.958f);
    }

    private void HealthLose()
    {
        if (curHealth <= 0 && Lives3.activeSelf)
        {
            LivesBar.GetComponent<Animation>().Play();
            Lives3.SetActive(false);
            Lives2.SetActive(true);
            curHealth = 100f;
        }
        if (curHealth <= 0 && Lives2.activeSelf)
        {
            LivesBar.GetComponent<Animation>().Play();
            Lives2.SetActive(false);
            Lives1.SetActive(true);
            curHealth = 100f;
        }
        if (curHealth <= 0 && Lives1.activeSelf)
        {
            LivesBar.GetComponent<Animation>().Play();
            Lives1.SetActive(false);
            curHealth = 100f;
        }
        if (curHealth <= 0 && Lives1.activeSelf == false)
        {
            PointsCalculate();
            StartCoroutine("SceneLoad");
        }
    }

    private void SmokeColourChange()
    {
        if (curHealth == 100f)
        {
            EngineSound.pitch = 0.9f;
            Smoke.SetActive(true);
            SmokeGray.SetActive(false);
            SmokeBlack.SetActive(false);
            SmokeBlackBlack.SetActive(false);
        }
        if (curHealth == 75f)
        {
            EngineSound.pitch = 0.85f;
            Smoke.SetActive(false);
            SmokeGray.SetActive(true);
        }
        if (curHealth == 50f)
        {
            EngineSound.pitch = 0.8f;
            SmokeGray.SetActive(false);
            SmokeBlack.SetActive(true);
        }
        if (curHealth == 25f)
        {
            EngineSound.pitch = 0.7f;
            SmokeBlack.SetActive(false);
            SmokeBlackBlack.SetActive(true);
        }
    }

    private void Explosion()
    {
        var instance = Instantiate(PlayerExplosion, player.GetComponent<Transform>().position,
            player.transform.rotation);
        Destroy(instance.gameObject, 2.0f);
    }

    private void PointsCalculate()
    {
        var Score = Convert.ToInt32(Points.text);
        PlayerPrefs.SetInt("ScoreMedium", Score);
        var ScoreEasyTop = PlayerPrefs.GetInt("ScoreMediumTop");
        if (Score > ScoreEasyTop)
            PlayerPrefs.SetInt("ScoreMediumTop", Score);
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