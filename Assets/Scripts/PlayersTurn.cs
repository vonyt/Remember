using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayersTurn : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI CountdownText;
    [SerializeField] AlienPlayerLevelTwo player;
    [SerializeField] ShooterTwo shot;
    [SerializeField] BossEnemyController enemyController;
    [SerializeField] Canvas countdownCanvas;
    public bool isPlayersTurn;
    public bool readyToStart = false;

    int count = 3;

    void Start()
    {
        StartCoroutine(IsPlayersTurn());
    }

    void Update(){
        isPlayersTurn = enemyController.playersTurn;
        //if (readyToStart) shot.gameObject.SetActive(true);
    }

    IEnumerator IsPlayersTurn(){
        while(!isPlayersTurn) yield return null;
        countdownCanvas.gameObject.SetActive(true);
        StartCoroutine(ShowCountdown());
    }

    IEnumerator ShowCountdown(){

        while(count > 0){
            CountdownText.text = count + "\n";
            yield return new WaitForSeconds(1.0f);
            count--;
        }

        CountdownText.text = "Go!\n";
        yield return new WaitForSeconds(1.0f);
        //Transform shooter = player.transform.Find("Shooter");
        //shooter.gameObject.SetActive(true);
        //shot.gameObject.SetActive(true);
        countdownCanvas.gameObject.SetActive(false);
        readyToStart = true;
    }
}
