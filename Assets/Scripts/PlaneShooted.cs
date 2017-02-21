using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooted : MonoBehaviour
{

    public HealthBar hit;

    public GameObject bullet;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            Destroy(bullet);
            Debug.Log("Shot!");
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(bullet);
            hit.DecreaseHealth();
            Debug.Log("Shot!");
        }
    }


}
