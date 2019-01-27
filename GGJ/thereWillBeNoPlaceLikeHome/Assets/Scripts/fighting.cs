using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighting : MonoBehaviour
{


    [SerializeField] BoxCollider2D punchColliderRight;
    [SerializeField] BoxCollider2D punchColliderLeft;
    AudioSource punchSource;
   [SerializeField] AudioClip[] punchClips;
    enemyHealth currEnemyHealth;
    Animator fightingController;
    float punchForceStraight = 1000.0f;
    float punchForceUp = 500.0f;
    bool onPunch1 = true;
    bool onPunch2 = false;
    bool onPunch3 = false;
    bool[] punchNumber = { false, false, false };

    void Start()
    {
        punchSource = GetComponent<AudioSource>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (mainHomeManager.singletonHomeManager.homeSpriteRenderer.flipX == true)
            {
                punchColliderLeft.enabled = true;
            }
            if (mainHomeManager.singletonHomeManager.homeSpriteRenderer.flipX == false)
            {
                punchColliderRight.enabled = true;
            }

        }
        else
        {
            punchColliderRight.enabled = false;
            punchColliderLeft.enabled = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objectCollidedWith = collision.gameObject;
        Rigidbody2D objectRigidbody = objectCollidedWith.GetComponent<Rigidbody2D>();
        if (objectCollidedWith.tag == "Enemy")
        {
            currEnemyHealth = objectCollidedWith.GetComponent<enemyHealth>();

            punchSource.PlayOneShot(punchClips[Random.Range(0, punchClips.Length - 1)], 0.5f);
            Debug.Log(currEnemyHealth);
            if (currEnemyHealth)
                currEnemyHealth.takeDamage();
            if (onPunch1)
                objectRigidbody.AddForce(new Vector2(punchForceStraight * 0.5f, 0.0f));
            else if (onPunch2)
                objectRigidbody.AddForce(new Vector2(punchForceStraight * 2.0f, punchForceUp * 0.5f));
            else if (onPunch3)
                objectRigidbody.AddForce(new Vector2(0.0f, punchForceUp * 2.0f));
        }
    }
     

}
