using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayerEasy: MonoBehaviour
{
    public Rigidbody2D EnemyBullet;
    public HealthBarEasy hit;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(EnemyBullet.gameObject);
            hit.DecreaseHealth();
        }
        if (coll.gameObject.tag == "Wall")
        {
            Destroy(EnemyBullet.gameObject);
        }
    }
}
