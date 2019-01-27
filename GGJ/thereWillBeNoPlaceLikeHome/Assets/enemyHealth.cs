using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

    private int health;
    private void Awake()
    {
        health = 3;
        
    }
    

    public void takeDamage()
    {
        Debug.Log("Health for this enemy is being checked");
        checkHealth();
        health -= 1;
    }

    private void checkHealth()
    {
        Debug.Log("This enemy has: " + health + " health");
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
