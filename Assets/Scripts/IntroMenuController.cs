using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IntroMenuController : MonoBehaviour
{
    [SerializeField] Image fader;
    float time = 0;
    public void StartGame(){
        StartCoroutine(fadeBackground());
    }

    IEnumerator fadeBackground(){
        Color color = fader.color;
        while (time < .80f){
            time+=Time.deltaTime;
            color.a = Mathf.Clamp01(time/.80f);
            fader.color = color;
            yield return null;
        } 

        SceneManager.LoadScene("LevelOneScene");
    }

    public void ExitGame(){
        StartCoroutine(fadeBackground());
        Application.Quit();
    }
}
