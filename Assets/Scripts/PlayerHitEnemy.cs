using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEnemy : MonoBehaviour
{

    public Rigidbody2D Bullet;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            Destroy(Bullet.gameObject);
            Debug.Log("Shot!");
        }
        if(coll.gameObject.tag == "Wall")
        {
            Destroy(Bullet.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            Destroy(Bullet.gameObject);
        }
    }
}
