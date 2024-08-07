using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedController : MonoBehaviour
{

    public void retryGame(){
        SceneManager.LoadScene("LevelOneScene");
    }

    public void exitGame(){
        Application.Quit();
    }
}
