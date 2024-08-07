using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FaderTwo : MonoBehaviour
{
    [SerializeField] Image fader;
    [SerializeField] Image fadeout;
    [SerializeField] Image portalfade;


    float time = 0;
    bool faded = false;
    void Awake(){
        StartCoroutine(fadeBackground());
    }

    public void PortalFade(){
        StartCoroutine(portalFader());
    }

    IEnumerator portalFader(){
        Color color = portalfade.color;
        time=0;
        while (time < .80f){
            time+=Time.deltaTime;
            color.a = Mathf.Clamp01(time/.80f);
            portalfade.color = color;
            yield return null;
        }
        SceneManager.LoadScene("MemoryGameScene");
    }

    void Update(){
        if(!faded && PointsAccessor.points == 15) {
            Debug.Log("supposed to start fadeout");
            StartCoroutine(fadeOut());
            faded = true;
        }
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
        SceneManager.LoadScene("LV1BossScene");
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
