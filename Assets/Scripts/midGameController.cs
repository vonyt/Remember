using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class midGameController : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuCanvas;
    public void PauseGame(){
        Time.timeScale = 0f;
        pauseMenuCanvas.gameObject.SetActive(true);
    }

    public void PlayGame(){
        Time.timeScale = 1f;
        pauseMenuCanvas.gameObject.SetActive(false);
    }

    public void StopGame(){
        SceneManager.LoadScene("StartScene");
    }
}
