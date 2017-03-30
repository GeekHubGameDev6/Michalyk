using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public GameObject background;
    public GameObject player;

    public float speedMultiplier = 0.3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        float y = -player.GetComponent<Transform>().localPosition.y + 0.1f;
        float x = background.GetComponent<Transform>().localPosition.x;
        background.transform.localPosition = new Vector3(x, y, 1);
        background.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime * speedMultiplier);
	}
}
