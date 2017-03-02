using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAI : MonoBehaviour
{
    public Rigidbody2D SpawnEnemy;

    public float timer = 3.0f;

    private bool flag = true;

    private GameObject[] target;

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
        
        var position = new Vector3(Random.Range(9.0f, 20.0f), Random.Range(-4.0f, 4.0f), 0);
        Rigidbody2D spawn = Instantiate(SpawnEnemy, position, transform.rotation);
        spawn.velocity = transform.TransformDirection(new Vector3(0, 0, 0));
    }

    void Find()
    {
        if (flag)
        {
            target = GameObject.FindGameObjectsWithTag("enemy");
            if (target.Length < 8)
            {
                spawn();
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemyTRIGGER")
        {
            Destroy(SpawnEnemy.gameObject);
            flag = false;
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemyTRIGGER")
        {
            Destroy(SpawnEnemy.gameObject);
            flag = false;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemyTRIGGER")
        {
            Destroy(SpawnEnemy.gameObject);
            flag = true;
        }
    }
}

