#region

using UnityEngine;

#endregion

public class ShipMove : MonoBehaviour
{
    public GameObject player;

    public GameObject ship;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.transform.position.y > -3.6f)
        {
            ship.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime);
            ship.GetComponent<Transform>().Translate(Vector3.down * Time.deltaTime);
        }

        if (ship.transform.position.y < -5.0f)
            ship.GetComponent<Transform>().position = new Vector2(-8f, -6f);
    }
}