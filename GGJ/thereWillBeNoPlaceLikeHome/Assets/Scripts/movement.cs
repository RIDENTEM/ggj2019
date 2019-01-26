using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Rigidbody2D homeRigidBody;
    SpriteRenderer homeSpriteRenderer;
    Vector3 refVector = Vector3.zero;
   [SerializeField] float runSpeed = 1.0f;
    public LayerMask groundLayer;
    float jumpSpeed = 400.0f;
    float horizontalMove = 0.0f;
    float smoothedMovement = 0.5f;
    //when true image is flipped to other side
    bool flippedX = false;
    bool inAir = false;
    bool grounded = true;
    void Start()
    {
        homeRigidBody = GetComponent<Rigidbody2D>();
        homeSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

    }

    void jump()
    {
        homeRigidBody.AddForce(new Vector2(0.0f, jumpSpeed));
    }

    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //homeRigidBody.AddForce(horizontalMove);
        Vector3 targetVelocity = new Vector2(horizontalMove * 10.0f, homeRigidBody.velocity.y);
        homeRigidBody.velocity = targetVelocity;
        

        if (grounded == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("jumped");
                jump();
                inAir = true;
            }
        }
        //if home is moving left and isn't flipped flip it left
        if (horizontalMove < 0)
        {
            flippedX = true;

        }
        //if home is moving right and is flipped flip it right
        if (horizontalMove > 0)
        {
            flippedX = false;
        }

        if (flippedX == true)
            homeSpriteRenderer.flipX = true;
        else if (flippedX == false)
            homeSpriteRenderer.flipX = false;
    }
}
