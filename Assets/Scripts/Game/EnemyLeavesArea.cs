using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLeavesArea : MonoBehaviour
{

    public GameObject ScoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            var i = Convert.ToInt32(ScoreText.GetComponent<Text>().text);
            if (i != 0)
            {
                i -= 10;
                ScoreText.GetComponent<Text>().text = i.ToString();
            }
            else
            {
                ScoreText.GetComponent<Text>().text = "0";
            }
            
        }
    }
}
