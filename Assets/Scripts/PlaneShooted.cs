﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooted : MonoBehaviour
{
    public GameObject bullet;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            Destroy(bullet);
        }
    }
}
