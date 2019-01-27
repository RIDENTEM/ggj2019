using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainHomeManager : MonoBehaviour
{

   public static mainHomeManager singletonHomeManager = null;

    private enemyManager manageEnemies;

    public SpriteRenderer homeSpriteRenderer;
    [SerializeField] Sprite[] homeSprites;
    static private int currentHouseImage = 0;

    Collider2D homeBodyCollider;
    public Rigidbody2D homeRigidBody;

    [SerializeField] GameObject respawnSpot;

    private void Awake()
    {
        if (singletonHomeManager == null)
            singletonHomeManager = this;

        respawnSpot = GameObject.FindGameObjectWithTag("homeSpawn");
    }

    void Start()
    {
        homeRigidBody = GetComponent<Rigidbody2D>();
        homeBodyCollider = GetComponent<BoxCollider2D>();

        homeSpriteRenderer = GetComponent<SpriteRenderer>();
        //homeSpriteRenderer.sprite = homeImages[currentHouseImage];
        
    }

    void fallCheck()
    {
        if(gameObject.transform.position.y <= -5.0f)
        {
            health.healthManager.gotHurt();
            respawn();
        }
    }
    void respawn()
    {
        gameObject.transform.position = respawnSpot.transform.position;
    }

    void changeHomeAppearance()
    {
        homeSpriteRenderer.sprite = homeSprites[currentHouseImage];
        currentHouseImage++;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health.healthManager.gotHurt();
            homeRigidBody.AddForce(new Vector2(Vector2.left.x * 2000.0f, 10.0f));


        }
    }

    void Update()
    {
        fallCheck();
    }
}
