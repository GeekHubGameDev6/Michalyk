﻿#region

using UnityEngine;

#endregion

public class PlayerHitEnemy : MonoBehaviour
{
    public Rigidbody2D Bullet;
    private int counter;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemy")
            Destroy(Bullet.gameObject);
        if (coll.gameObject.tag == "Wall")
            Destroy(Bullet.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
            Destroy(Bullet.gameObject);
    }
}