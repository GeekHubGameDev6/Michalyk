#region

using UnityEngine;

#endregion

public class MoveEnemy : MonoBehaviour
{
    public GameObject enemyAI;
    public int speed = 2;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        enemyAI.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * speed, ForceMode2D.Force);
    }
}