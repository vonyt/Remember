using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PortalFader : MonoBehaviour
{
    [SerializeField] Image fader;
    [SerializeField] Image fadeout;

    float time = 0;
    //bool faded = false;
    void Awake(){
        StartCoroutine(fadeBackground());
    }

    public void WinnerFadeOut(){
        StartCoroutine(WinnerFade());
    }

    public IEnumerator WinnerFade(){
        Color color = fadeout.color;
        time=0;
        while (time < .80f){
            time+=Time.deltaTime;
            color.a = Mathf.Clamp01(time/.80f);
            fadeout.color = color;
            yield return null;
        }
        SceneManager.LoadScene("LevelTwoScene");
    }

    public void LoserFadeOut(){
        StartCoroutine(LoserFade());
    }

    public IEnumerator LoserFade(){
        Debug.Log("should be fading out now");
        Color color = fadeout.color;
        time=0;
        while (time < .80f){
            time+=Time.deltaTime;
            color.a = Mathf.Clamp01(time/.80f);
            fadeout.color = color;
            yield return null;
        }
        SceneManager.LoadScene("LevelTwoScene");
    }


    IEnumerator fadeBackground(){
        Color color = fader.color;
        while (time < .80f){
            time+=Time.deltaTime;
            color.a = Mathf.Clamp01(1f - (time/.80f));
            fader.color = color;
            yield return null;
        }
    } 
}
