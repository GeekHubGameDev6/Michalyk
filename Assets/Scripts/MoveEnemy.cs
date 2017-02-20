using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    public GameObject enemyAI;
    public int ForceStrength = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemyAI.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * ForceStrength, ForceMode2D.Force);
    }
}
