#region

using System;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class EnemyGetsHit : MonoBehaviour
{
    private int counter;
    public GameObject EnemyExplosion;
    public GameObject enemySmoke;
    public GameObject enemySmokeHitted;
    public GameObject enemySmokeHitted2;
    public GameObject enemySmokeHitted3;
    public GameObject Score;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "bullet")
            counter += 1;

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

    private void Explosion()
    {
        var instance = Instantiate(EnemyExplosion, gameObject.GetComponent<Transform>().position,
            gameObject.transform.rotation);
        Destroy(instance.gameObject, 2.0f);
    }

    private void ScoreCalculate()
    {
        var i = Convert.ToInt32(Score.GetComponent<Text>().text);
        i += 10;
        Score.GetComponent<Text>().text = i.ToString();
    }
}