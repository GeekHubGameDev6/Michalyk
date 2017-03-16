﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject Smoke;
    public GameObject SmokeGray;
    public GameObject SmokeBlack;
    public GameObject SmokeBlackBlack;

    public GameObject ship;
    public GameObject player;
    public GameObject healthbar;
    public float Health = 100f;
    public float curHealth;


    public GameObject Lives3;
    public GameObject Lives2;
    public GameObject Lives1;


    private int i = 1;
    // Use this for initialization
    void Start ()
	{
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
        curHealth -= 25f;
        float calc_Health = curHealth / Health;
        SetHealthBar(calc_Health);
        SmokeColourChange();
        HealthLose();
        Debug.Log(curHealth);
        
    }

    void PlayerKilled()
    {
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
            Lives3.SetActive(false);
            Lives2.SetActive(true);
            curHealth = 100f;
        }
        if (curHealth <= 0 && Lives2.activeSelf)
        {
            Lives2.SetActive(false);
            Lives1.SetActive(true);
            curHealth = 100f;
        }
        if (curHealth <= 0 && Lives1.activeSelf)
        {
            Lives1.SetActive(false);
            curHealth = 100f;
        }
        if (curHealth <= 0 && Lives1.activeSelf==false)
        {
            Debug.Log("Game Over");
        }
    }

    void SmokeColourChange()
    {
        if (curHealth == 100f)
        {
            Smoke.SetActive(true);
            SmokeGray.SetActive(false);
            SmokeBlack.SetActive(false);
            SmokeBlackBlack.SetActive(false);
        }
        if (curHealth == 75f)
        {
            Smoke.SetActive(false);
            SmokeGray.SetActive(true);
        }
        if (curHealth == 50f)
        {
            SmokeGray.SetActive(false);
            SmokeBlack.SetActive(true);
        }
        if (curHealth == 25f)
        {
            SmokeBlack.SetActive(false);
            SmokeBlackBlack.SetActive(true);
        }
    }
}
