using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public AudioSource EnemyHitsPlayer;
    public AudioSource EngineSound;

    public GameObject Smoke;
    public GameObject SmokeGray;
    public GameObject SmokeBlack;
    public GameObject SmokeBlackBlack;

    public GameObject ship;
    public GameObject player;
    public GameObject healthbar;
    public float Health = 100f;
    public float curHealth;

    public GameObject PlayerExplosion;

    public GameObject LivesBar;

    public GameObject Lives3;
    public GameObject Lives2;
    public GameObject Lives1;

    public Text Points;

    // Use this for initialization
    void Start ()
	{
        EngineSound.PlayDelayed(1f);
	    curHealth = Health;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
    }

    void SetHealthBar(float myHealth)
    {
        healthbar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthbar.transform.localScale.y, healthbar.transform.localScale.z);
        if (curHealth == 0)
        {
            //HealthLose();
            healthbar.transform.localScale = new Vector3(1f, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
            PlayerKilled();
        }
    }

    public void DecreaseHealth()
    {
        EnemyHitsPlayer.Play();

        curHealth -= 25f;
        float calc_Health = curHealth / Health;
        SetHealthBar(calc_Health);
        
        HealthLose();
        SmokeColourChange();
        Debug.Log(curHealth);
        
    }

    void PlayerKilled()
    {
        Explosion();
        SmokeColourChange();
        ship.GetComponent<Transform>().position = new Vector2(-5.27f, -4.27f);
        Debug.Log("Player Killed!");
        var rotationVector = player.transform.rotation.eulerAngles;
        rotationVector.z = 12.107f;
        player.transform.rotation = Quaternion.Euler(rotationVector);
        player.GetComponent<Transform>().position = new Vector3(-5.594f, -3.958f);
    }

    void HealthLose()
    {
        if (curHealth <=0 && Lives3.activeSelf)
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
        if (curHealth <= 0 && Lives1.activeSelf==false)
        {
            PointsCalculate();
            StartCoroutine("SceneLoad");
            //Debug.Log("Game Over");
        }
    }

    void SmokeColourChange()
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

    void Explosion()
    {
        var instance = Instantiate(PlayerExplosion, player.GetComponent<Transform>().position, player.transform.rotation);
        Destroy(instance.gameObject, 2.0f);
    }

    void PointsCalculate()
    {
        var Score = Convert.ToInt32(Points.text);
        PlayerPrefs.SetInt("ScoreEasy", Score);
        var ScoreEasyTop = PlayerPrefs.GetInt("ScoreEasyTop");

        if (Score > ScoreEasyTop)
        {
            PlayerPrefs.SetInt("ScoreEasyTop", Score);
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
