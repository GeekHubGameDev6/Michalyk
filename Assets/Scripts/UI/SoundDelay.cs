﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDelay : MonoBehaviour
{

    public AudioSource ShipHorn;
    public AudioSource Ambient1;
    public AudioSource Ambient2;
    // Use this for initialization
    void Start () {
        ShipHorn.PlayDelayed(1f);
        Ambient1.PlayDelayed(1f);
        Ambient2.PlayDelayed(1f);
    }
	
	// Update is called once per frame
	void Update () {
    }
}
