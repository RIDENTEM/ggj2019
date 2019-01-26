using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainHomeManager : MonoBehaviour
{

    private SpriteRenderer homeSpriteRenderer;
    private enemyManager manageEnemies;
    [SerializeField] Sprite[] homeImages;
    static private int currentHouseImage = 0;

    void Start()
    {
        homeSpriteRenderer = GetComponent<SpriteRenderer>();
        homeSpriteRenderer.sprite = homeImages[currentHouseImage];

    }

    void changeHomeAppearance()
    {
        homeSpriteRenderer.sprite = homeImages[currentHouseImage];
        currentHouseImage++;
    }


    void Update()
    {

    }
}
