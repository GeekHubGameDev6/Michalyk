#region

using UnityEngine;

#endregion

public class EnemyHitPlayerHard : MonoBehaviour
{
    public Rigidbody2D EnemyBullet;
    public HealthBarHard hit;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(EnemyBullet.gameObject);
            hit.DecreaseHealth();
        }
        if (coll.gameObject.tag == "Wall")
            Destroy(EnemyBullet.gameObject);
    }
}