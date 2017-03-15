using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitsTheFloor : MonoBehaviour
{
    public GameObject player;
    public GameObject ship;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            ship.GetComponent<Transform>().position = new Vector2(-5.27f, -4.27f);
            var rotationVector = player.transform.rotation.eulerAngles;
            rotationVector.z = 12.107f;
            player.transform.rotation = Quaternion.Euler(rotationVector);
            player.GetComponent<Transform>().position = new Vector3(-5.594f, -3.958f);
            Debug.Log("Player killed himself");
            
        }
    }
}
