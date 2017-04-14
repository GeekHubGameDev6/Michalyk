#region

using System;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class EnemyLeavesArea : MonoBehaviour
{
    public GameObject ScoreText;

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("enemy"))
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