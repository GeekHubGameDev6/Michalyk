#region

using UnityEngine;

#endregion

public class SpawnAI : MonoBehaviour
{
    public int EnemyAmount;
    private bool flag = true;
    public Rigidbody2D SpawnEnemy;
    private GameObject[] target;

    private void Update()
    {
        if (flag)
        {
            target = GameObject.FindGameObjectsWithTag("enemy");
            if (target.Length < EnemyAmount)
            {
                var x = Random.Range(9f, 20f);
                var y = Random.Range(-4f, 4f);
                var position = new Vector3(x, y, 0);
                var spawn = Instantiate(SpawnEnemy, position, transform.rotation);
                spawn.velocity = transform.TransformDirection(new Vector3(0, 0, 0));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("enemyTRIGGER"))
        {
            Destroy(SpawnEnemy.gameObject);
            flag = false;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("enemyTRIGGER"))
        {
            Destroy(SpawnEnemy.gameObject);
            flag = true;
        }
    }
}