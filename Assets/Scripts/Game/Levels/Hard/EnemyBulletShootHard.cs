﻿#region

using UnityEngine;

#endregion

public class EnemyBulletShootHard : MonoBehaviour
{
    public Rigidbody2D EnemyBulletHard;

    public AudioSource EnemyShootSound;
    private bool flag = true;
    public float speed = 20;

    public float timer = 4.0f;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f && flag)
        {
            flag = false;
            timerEnded();
        }
    }

    private void timerEnded()
    {
        EnemyShootSound.Play();
        var fire = Instantiate(EnemyBulletHard, transform.position, transform.rotation);
        fire.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
        Destroy(fire.gameObject, 0.8f);
        timer = Random.Range(3.0f, 5.0f);
        flag = true;
    }
}