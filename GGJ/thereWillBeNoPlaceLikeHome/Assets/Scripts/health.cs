using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

    public static health healthManager;
    private int maxHealth = 3;
    public static int currentHealth;
    [SerializeField] SpriteRenderer[] healthBar;

    private void Start()
    {
        healthManager = this;
        currentHealth = maxHealth;
        for (int i = 0; i < healthBar.Length; i++)
            healthBar[i].color = Color.green;

    }

     public void gotHurt()
    {
        currentHealth -= 1;
        healthBar[currentHealth].color = Color.red;
    }
    
}
