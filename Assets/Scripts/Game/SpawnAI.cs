using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SpawnAI : MonoBehaviour
{
    public Rigidbody2D SpawnEnemy;

    private bool flag = true;
    public int EnemyAmount;

    private GameObject[] target;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            target = GameObject.FindGameObjectsWithTag("enemy");
            if (target.Length < EnemyAmount)
            {
                var x = Random.Range(9f, 20f);
                var y = Random.Range(-4f, 4f);
                var position = new Vector3(x, y, 0);
                Rigidbody2D spawn = Instantiate(SpawnEnemy, position, transform.rotation);
                spawn.velocity = transform.TransformDirection(new Vector3(0, 0, 0));
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

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemyTRIGGER")
        {
            Destroy(SpawnEnemy.gameObject);
            flag = true;
        }
    }
}

