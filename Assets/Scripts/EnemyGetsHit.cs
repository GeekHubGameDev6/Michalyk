using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetsHit : MonoBehaviour
{

    public GameObject AI;
    public GameObject enemySmoke;
    public GameObject enemySmokeHitted;
    public GameObject enemySmokeHitted2;
    public GameObject enemySmokeHitted3;
    private int counter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
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
            Destroy(gameObject);
        }
    }
}
