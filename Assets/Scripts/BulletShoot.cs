using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletShoot : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float speed = 1;
    public Button Fire;

    public void Shoot()
    {
        Rigidbody2D fire = Instantiate(bullet, transform.position, transform.rotation);
        fire.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
        Destroy(fire.gameObject, 0.8f);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        Rigidbody2D fire = Instantiate(bullet, transform.position, transform.rotation);
	        fire.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
            Destroy(fire.gameObject, 0.8f);
        }

    }
    

}
