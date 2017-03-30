using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayer: MonoBehaviour
{
    public Rigidbody2D EnemyBullet;

    public HealthBar hit;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(EnemyBullet.gameObject);
            hit.DecreaseHealth();
            Debug.Log("You have been shot!");
        }
        if (coll.gameObject.tag == "Wall")
        {
            Destroy(EnemyBullet.gameObject);
        }
    }
}
