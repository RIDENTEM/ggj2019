using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemyManager : MonoBehaviour
{
    
    public int enemiesInLevel;
    private int currentScene;


    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        
        enemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy").Length;

    }

    public void allEnemiesDeadCheck()
    {
        if (enemiesInLevel <= 0)
        {
            if (SceneManager.sceneCount > 0)
            {
                //exit level, move on to the next
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    void Update()
    {
        allEnemiesDeadCheck();
    }
}
