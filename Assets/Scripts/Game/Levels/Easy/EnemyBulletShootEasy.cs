using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBulletShootEasy : MonoBehaviour
{

    public AudioSource EnemyShootSound;

    public Rigidbody2D EnemyBulletEasy;
    public float speed = 20;

    public float timer = 4.0f;
    private bool flag = true;

    void Start () {
		
	}

	void FixedUpdate ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f && flag)
        {
            flag = false;
            timerEnded();
        }
    }

    void timerEnded()
    {
        EnemyShootSound.Play();
        Rigidbody2D fire = Instantiate(EnemyBulletEasy, transform.position, transform.rotation);
        fire.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
        Destroy(fire.gameObject, 0.8f);
        timer = Random.Range(3.0f,5.0f);
        flag = true;
    }
}
