using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMenu : MonoBehaviour {

    public void changeScene()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
