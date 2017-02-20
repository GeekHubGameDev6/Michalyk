using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBulletShoot : MonoBehaviour {

    public Rigidbody2D bullet;
    public float speed = 1;

    public float timer = 3.0f;
    private bool flag = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
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
        Rigidbody2D fire = Instantiate(bullet, transform.position, transform.rotation);
        fire.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
        Destroy(fire.gameObject, 0.8f);
        timer = 3.0f;
        flag = true;
    }
}
