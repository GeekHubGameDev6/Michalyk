using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAI : MonoBehaviour
{

    public Rigidbody2D SpawnEnemy;

    private GameObject[] target;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Find();
    }

    void spawn()
    {
        {
            var position = new Vector3(Random.Range(7, 11), Random.Range(-4.0f, 4.0f), 0);
            Rigidbody2D spawn = Instantiate(SpawnEnemy, position, transform.rotation);
            spawn.velocity = transform.TransformDirection(new Vector3(0, 0, 0));
        }
    }

    void Find()
    {
        target = GameObject.FindGameObjectsWithTag("enemy");
        if (target.Length < 5)
        {
            spawn();
        }
    }
}

