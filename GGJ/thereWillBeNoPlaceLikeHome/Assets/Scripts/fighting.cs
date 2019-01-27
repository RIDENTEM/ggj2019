using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighting : MonoBehaviour
{


    [SerializeField] BoxCollider2D punchCollider;
    Animator fightingController;
    float punchForceStraight = 10.0f;
    float punchForceUp = 5.0f;
    bool onPunch1 = true;
    bool onPunch2 = false;
    bool onPunch3 = false;
    bool[] punchNumber = { false, false, false };

    void Start()
    {


    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            punchCollider.enabled = true;
            // fightingController.play

        }
        else
            punchCollider.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objectCollidedWith = collision.gameObject;
        Rigidbody2D objectRigidbody = objectCollidedWith.GetComponent<Rigidbody2D>();
        if (objectCollidedWith.tag == "Enemy")
        {
            if (onPunch1)
                objectRigidbody.AddForce(new Vector2(punchForceStraight * 0.5f, 0.0f));
            else if (onPunch2)
                objectRigidbody.AddForce(new Vector2(punchForceStraight * 2.0f, punchForceUp * 0.5f));
            else if (onPunch3)
                objectRigidbody.AddForce(new Vector2(0.0f, punchForceUp * 2.0f));
        }
    }
}
