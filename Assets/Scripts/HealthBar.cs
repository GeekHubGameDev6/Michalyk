using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject healthbar;
    public float Health = 100f;
    public float curHealth;
	// Use this for initialization
	void Start ()
	{
	    curHealth = Health;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        

    }

    void SetHealthBar(float myHealth)
    {
        healthbar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthbar.transform.localScale.y, healthbar.transform.localScale.z);
        if (curHealth == 0)
        {
            PlayerKilled();
        }
    }

    public void DecreaseHealth()
    {
            curHealth -= 25f;
            float calc_Health = curHealth / Health;
            SetHealthBar(calc_Health);
            Debug.Log(curHealth);
        
    }

    void PlayerKilled()
    {
        Debug.Log("Player Killed!");
    }
}
