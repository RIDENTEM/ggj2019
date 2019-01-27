using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Vector3 refVector = Vector3.zero;
    private float runSpeed = 4.0f;
    [SerializeField] GameObject groundCheck;
    AudioSource playerMoveSource;
    AudioClip[] movementClips;
    public LayerMask groundLayer; 
    float jumpSpeed = 400.0f;
    float horizontalMove = 0.0f;
    float smoothedMovement = 0.5f;
    //when true image is flipped to other side
    bool flippedX = false;
    public bool grounded = true;

    private void Start()
    {
        playerMoveSource = GetComponent<AudioSource>();
    }

    void checkIfGrounded()
    {
        if (Physics2D.OverlapCircle(groundCheck.transform.position, 0.5f, LayerMask.GetMask("ground")))
        {
            grounded = true;
        }

        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                grounded = false;

                mainHomeManager.singletonHomeManager.homeRigidBody.AddForce(new Vector2(0.0f, jumpSpeed * 5.0f));
            }
        }
    }

    void flipSprite(float horizontalDirection)
    {

        //if home is moving left and isn't flipped flip it left
        if (horizontalDirection < 0)
        {
            mainHomeManager.singletonHomeManager.homeSpriteRenderer.flipX = true;

        }
        //if home is moving right and is flipped flip it right
        if (horizontalDirection > 0)
        {
            mainHomeManager.singletonHomeManager.homeSpriteRenderer.flipX = false;
        }
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horizontalMove != 0)
        {
            playerMoveSource.volume = 1.0f;
        }
        else
            playerMoveSource.volume = 0.0f;
        Vector3 targetVelocity = new Vector2(horizontalMove * 5.0f, mainHomeManager.singletonHomeManager.homeRigidBody.velocity.y);

        mainHomeManager.singletonHomeManager.homeRigidBody.velocity = targetVelocity;
        flipSprite(targetVelocity.x);

        checkIfGrounded();
    }



}
