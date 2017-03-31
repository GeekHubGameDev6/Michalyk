﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGetsHit : MonoBehaviour
{
    public GameObject EnemyExplosion;
    public GameObject Score;
    public GameObject enemySmoke;
    public GameObject enemySmokeHitted;
    public GameObject enemySmokeHitted2;
    public GameObject enemySmokeHitted3;
    private int counter;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            counter += 1;
        }

        if (counter == 3)
        {
            enemySmoke.SetActive(true);
            enemySmokeHitted.SetActive(true);
        }

        if (counter == 4)
        {
            enemySmokeHitted.SetActive(false);
            enemySmokeHitted2.SetActive(true);
        }

        if (counter == 5)
        {
            enemySmokeHitted2.SetActive(false);
            enemySmokeHitted3.SetActive(true);
        }
        if (counter == 6)
        {
            ScoreCalculate();
            Explosion();
            Destroy(gameObject);
        }
    }

    void Explosion()
    {
        var instance = Instantiate(EnemyExplosion, gameObject.GetComponent<Transform>().position, gameObject.transform.rotation);
        Destroy(instance.gameObject, 2.0f);
    }

    void ScoreCalculate()
    {
        var i = Convert.ToInt32(Score.GetComponent<Text>().text);
        i += 10;
        Score.GetComponent<Text>().text = i.ToString();
    }
}
