using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelThreeFader : MonoBehaviour
{
    [SerializeField] Image fadeInto;
    [SerializeField] Image fadeout;

    float time = 0;
    bool faded = false;
    void Awake(){
        StartCoroutine(fadeBackground());
    }

    void Update(){
        if(!faded && PointsAccessor.points == 15) {
            StartCoroutine(fadeOut());
            faded = true;
        }
    }

    public void LoserFading(){
        StartCoroutine(LoserFade());
    }
    
    IEnumerator LoserFade(){
        Color color = fadeout.color;
        time=0;
        while (time < .80f){
            time+=Time.deltaTime;
            color.a = Mathf.Clamp01(time/.80f);
            fadeout.color = color;
            yield return null;
        }
        PointsAccessor.points = 0; 
        SceneManager.LoadScene("QuitGameScene");
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
        SceneManager.LoadScene("LV2BossScene");
    }

    IEnumerator fadeBackground(){
        Color color = fadeInto.color;
        while (time < .80f){
            time+=Time.deltaTime;
            color.a = Mathf.Clamp01(1f - (time/.80f));
            fadeInto.color = color;
            yield return null;
        }
    } 
}
