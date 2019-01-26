using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

    private int maxHealth = 3;
    public static int currentHealth;
    Collider2D homeBodyCollider;
    Rigidbody2D homeRigidBody;
    [SerializeField] SpriteRenderer[] healthBar;
    

	void Start () {
        homeRigidBody = GetComponent<Rigidbody2D>();
        for (int i = 0; i < healthBar.Length; i++)
            healthBar[i].color = Color.green;
        currentHealth = maxHealth;
        homeBodyCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    if(collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 1;
            healthBar[currentHealth].color = Color.red;
            homeRigidBody.AddForce(new Vector2(Vector2.left.x, 1.0f));
        }
    }

    void Update () {
		
	}
}
