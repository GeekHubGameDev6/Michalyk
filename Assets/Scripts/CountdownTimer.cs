using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

    // Use this for initialization
    public float timeLeft = 150.0f;

    public Text TimerText;



    void Update()
    {
        timeLeft -= Time.deltaTime;
        TimerText.text = Mathf.Round(timeLeft).ToString();
        if (timeLeft < 0)
        {
            Debug.Log("EndGame");
        }
    }
}
