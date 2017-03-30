using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Experimental.Director;
using UnityEngine.UI;

public class BulletShoot : MonoBehaviour
{
    public AudioSource GunShootSound;
    public AudioSource ReloadingSound;
    public AudioSource EmptyLoader;

    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    public GameObject bar4;
    public GameObject bar5;

    public GameObject BWR;

    public GameObject reloading;

    public Text TextAnimation;
    public GameObject AmmoBar;

    public Rigidbody2D bullet;
    public float speed = 1;
    public Button Fire;

    public float ReloadTimer = 4.0f;
    private bool flag = false;

    public void Shoot()
    {
        if (reloading.activeSelf == false)
        {
            Rigidbody2D fire = Instantiate(bullet, transform.position, transform.rotation);
            fire.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
            Destroy(fire.gameObject, 0.8f);
            GunShootSound.Play();

            if (bar5.activeSelf)
            {

                bar4.SetActive(true);
                bar5.SetActive(false);
                AmmoBar.GetComponent<Animation>().Play();
            }
            else if (bar4.activeSelf)
            {

                bar3.SetActive(true);
                bar4.SetActive(false);
                AmmoBar.GetComponent<Animation>().Play();
            }
            else if (bar3.activeSelf)
            {

                bar2.SetActive(true);
                bar3.SetActive(false);
                AmmoBar.GetComponent<Animation>().Play();
            }
            else if (bar2.activeSelf)
            {

                bar1.SetActive(true);
                bar2.SetActive(false);
                AmmoBar.GetComponent<Animation>().Play();
            }
            else if (bar1.activeSelf)
            {
                BWR.SetActive(true);
                flag = true;
                bar1.SetActive(false);
                reloading.SetActive(true);
                TextAnimation.GetComponent<Text>().text = "Reloading";
                TextAnimation.GetComponent<Animation>().Play();
                AmmoBar.GetComponent<Animation>().Play();
            }
        
    }
    }
    void Start () {
		
	}

    void timerEnded()
    {
        ReloadingSound.Play();
        reloading.SetActive(false);
        BWR.SetActive(false);
        TextAnimation.GetComponent<Text>().text = "Ready";
        TextAnimation.GetComponent<Animation>().Play();
        bar5.SetActive(true);
        ReloadTimer = 4.0f;
        flag = false;
    }

    void FixedUpdate()
    {
        if (flag)
        {
            ReloadTimer -= Time.deltaTime;
            if (ReloadTimer <= 0.0f && flag)
            {
                bar5.SetActive(true);
                timerEnded();
            }
        }
    }

    // Update is called once per frame
    void Update () {
	    if (Input.GetKeyDown(KeyCode.Space) && reloading.activeSelf == false)
	    {
	        Rigidbody2D fire = Instantiate(bullet, transform.position, transform.rotation);
	        fire.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
            Destroy(fire.gameObject, 0.8f);
            GunShootSound.Play();

            if (bar5.activeSelf)
	        {
                
                bar4.SetActive(true);
                bar5.SetActive(false);
                AmmoBar.GetComponent<Animation>().Play();
            }
            else if (bar4.activeSelf)
            {
                
                bar3.SetActive(true);
                bar4.SetActive(false);
                AmmoBar.GetComponent<Animation>().Play();
            }
            else if (bar3.activeSelf)
            {
                
                bar2.SetActive(true);
                bar3.SetActive(false);
                AmmoBar.GetComponent<Animation>().Play();
            }
            else if (bar2.activeSelf)
            {
                
                bar1.SetActive(true);
                bar2.SetActive(false);
                AmmoBar.GetComponent<Animation>().Play();
            }
            else if (bar1.activeSelf)
	        {
                BWR.SetActive(true);
                flag = true;
                bar1.SetActive(false);
                reloading.SetActive(true);
	            TextAnimation.GetComponent<Text>().text = "Reloading";
	            TextAnimation.GetComponent<Animation>().Play();
                AmmoBar.GetComponent<Animation>().Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && reloading.activeSelf)
        {
            EmptyLoader.Play();
        }
    }
}
