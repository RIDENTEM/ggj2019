using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Vector3 refVector = Vector3.zero;
    [SerializeField] float runSpeed = 1.0f;
    [SerializeField] GameObject groundCheck;
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
    }

    void checkIfGrounded()
    {
        if (Physics2D.OverlapCircle(groundCheck.transform.position, 0.15f, LayerMask.GetMask("ground")))
        {
            grounded = true;
        }
        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("jumped");
                grounded = false;

                mainHomeManager.singletonHomeManager.homeRigidBody.AddForce(new Vector2(0.0f, jumpSpeed));
                inAir = true;
            }
        }
    }

    void flipSprite(float horizontalDirection)
    {

        //if home is moving left and isn't flipped flip it left
        if (horizontalDirection < 0)
        {
            mainHomeManager.singletonHomeManager.homeSpriteRenderer .flipX = false;

        }
        //if home is moving right and is flipped flip it right
        if (horizontalDirection > 0)
        {
            mainHomeManager.singletonHomeManager.homeSpriteRenderer.flipX = true;
        }
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Vector3 targetVelocity = new Vector2(horizontalMove * 5.0f, mainHomeManager.singletonHomeManager.homeRigidBody.velocity.y);

        mainHomeManager.singletonHomeManager.homeRigidBody.velocity = targetVelocity;
        flipSprite(targetVelocity.x);

    }



}
