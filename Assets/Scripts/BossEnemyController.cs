using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : MonoBehaviour
{
    [SerializeField] int order;
    [SerializeField] AlienPlayerLevelTwo player;
    [SerializeField] public GameObject[] bosses = new GameObject[5];
    [SerializeField] public GameObject[] correctOrder = new GameObject[5];
    LV1BossEnemy currentBoss;
    SpriteRenderer sprite;
    Transform goalPosition;
    bool next = true;
    public bool playersTurn = false;
    int i = 0;


    void Update(){
        if(i >= bosses.Length){
            playersTurn = true;
            return;
        }
        if(!next) return;
        currentBoss = bosses[i]?.GetComponent<LV1BossEnemy>();
        if(currentBoss != null && currentBoss.atPosition){
            StartCoroutine(DeathPattern());
        }
    }

    IEnumerator DeathPattern(){
        next = false;
        if(currentBoss == null) yield break;
        //Debug.Log("Starting deathpattern for boss: " + currentBoss.order);
        if(currentBoss.order != i) yield break;
        sprite = currentBoss.GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        currentBoss.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        next = true;
        i++;
   } 
}

