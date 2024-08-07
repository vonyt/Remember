using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextControllerTwo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI failureText;
    [SerializeField] TextMeshProUGUI winningText;
    [SerializeField] SecondMemoryFading script;
    RectTransform failureRect;
    RectTransform winningRect;
    [SerializeField] GameObject failureCover;
    [SerializeField] SecondAlienPlayerPortal player;
    int speed = 50;
    Vector3 textPos;
    bool called = false;
    Vector3 goalPos = new Vector3(0,0,0);

    void Update(){
        if(player.failed && !called) {
            StartCoroutine(moveFailure()); 
            called = true; 
            Debug.Log("calling moveFailure");
        }
            if(player.hasWon & !called){
            StartCoroutine(moveWinning());
            called = true;
        }
    }

    public IEnumerator moveFailure(){
        failureCover.SetActive(true);
        failureRect = failureText.GetComponent<RectTransform>();
        textPos = failureRect.anchoredPosition;
        float step = speed * Time.deltaTime;

        while(Vector3.Distance(textPos, goalPos) > 0.001f){
            textPos = Vector3.MoveTowards(textPos, goalPos, step);
            failureRect.anchoredPosition = textPos;
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
        script.Fading();
    }

    public IEnumerator moveWinning(){
        failureCover.SetActive(true);
        winningRect = winningText.GetComponent<RectTransform>();
        textPos = winningRect.anchoredPosition;
        float step = speed * Time.deltaTime;

        while(Vector3.Distance(textPos, goalPos) > 0.001f){
            textPos = Vector3.MoveTowards(textPos, goalPos, step);
            winningRect.anchoredPosition = textPos;
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
        script.Fading();
    }
}
