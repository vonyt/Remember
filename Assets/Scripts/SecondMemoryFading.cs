using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SecondMemoryFading : MonoBehaviour
{
    [SerializeField] Image fadeIn;
    [SerializeField] Image fadeout;

    float time = 0;
    bool faded = false;
    void Awake(){
        StartCoroutine(fadeBackground());
    }

    void Update(){
        if(!faded && PointsAccessor.points == 10) {
            StartCoroutine(fadeOut());
            faded = true;
        }
    }

  public void Fading(){
    StartCoroutine(fadeOut());
  }

    public IEnumerator fadeOut(){
        Color color = fadeout.color;
        time=0;
        while (time < .80f){
            time+=Time.deltaTime;
            color.a = Mathf.Clamp01(time/.80f);
            fadeout.color = color;
            yield return null;
        }
        PointsAccessor.points = 0; 
        SceneManager.LoadScene("LevelThreeScene");
    }

    IEnumerator fadeBackground(){
        Color color = fadeIn.color;
        while (time < .80f){
            time+=Time.deltaTime;
            color.a = Mathf.Clamp01(1f - (time/.80f));
            fadeIn.color = color;
            yield return null;
        }
    } 
}
