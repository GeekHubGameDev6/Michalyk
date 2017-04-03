using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartupPosFix : MonoBehaviour
{

    public GameObject Player;

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.acceleration.x < -0.15)
            {
                Player.transform.Rotate(-Vector3.forward * 150 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.acceleration.x > 0.15)
            {
                Player.transform.Rotate(Vector3.forward * 150 * Time.deltaTime);
            }
        }
    }
}
