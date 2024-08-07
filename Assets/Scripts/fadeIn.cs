using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class fadeIn : MonoBehaviour
{
    [SerializeField] Image fader;
    [SerializeField] Image fadeout;

    [SerializeField] AlienPlayer player;
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
