using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainHomeManager : MonoBehaviour
{

   public static mainHomeManager singletonHomeManager = null;

    private enemyManager manageEnemies;

    public SpriteRenderer homeSpriteRenderer;
    [SerializeField] Sprite[] homeImages;
    static private int currentHouseImage = 0;

    Collider2D homeBodyCollider;
    public Rigidbody2D homeRigidBody;
     

    private void Awake()
    {
        if (singletonHomeManager == null)
            singletonHomeManager = this;
        
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
        if(gameObject.transform.position.y <= 5.0f)
        {
            health.healthManager.gotHurt();
        }
    }

    void changeHomeAppearance()
    {
        homeSpriteRenderer.sprite = homeImages[currentHouseImage];
        currentHouseImage++;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health.healthManager.gotHurt();
            homeRigidBody.AddForce(new Vector2(Vector2.left.x, 1.0f));


        }
    }

    void Update()
    {
        
    }
}
