using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public static health healthManager;
    private int maxHealth = 3;
    private int currentHealth;
    [SerializeField] GameObject[] healthBar;

    private void Awake()
    {
        healthManager = this;
        currentHealth = maxHealth;

    }
    private void Start()
    {
        for (int i = 0; i < healthBar.Length; i++)
            healthBar[i].SetActive(true);

    }

    public void gotHurt()
    {
        if (currentHealth > 0)
        {

            currentHealth -= 1;
            healthBar[currentHealth].SetActive(false);
        }
    }

}
