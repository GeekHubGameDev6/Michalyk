﻿#region

using UnityEngine;
using UnityEngine.UI;

#endregion

public class BulletShoot : MonoBehaviour
{
    public GameObject AmmoBar;
    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    public GameObject bar4;
    public GameObject bar5;
    public Rigidbody2D bullet;
    public GameObject BWR;
    public AudioSource EmptyLoader;
    private bool flag;
    public AudioSource GunShootSound;
    public GameObject reloading;
    public AudioSource ReloadingSound;
    public float ReloadTimer = 4.0f;
    public float speed = 1;
    public Text TextAnimation;

    public void Shoot()
    {
        if (reloading.activeSelf == false)
        {
            var fire = Instantiate(bullet, transform.position, transform.rotation);
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
        else if (reloading.activeSelf)
        {
            EmptyLoader.Play();
        }
    }

    private void timerEnded()
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

    private void FixedUpdate()
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && reloading.activeSelf == false)
        {
            var fire = Instantiate(bullet, transform.position, transform.rotation);
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