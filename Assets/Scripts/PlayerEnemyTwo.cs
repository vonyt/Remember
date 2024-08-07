using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyTwo : MonoBehaviour
{
    [SerializeField] BossEnemyControllerTwo enemyContr;
    [SerializeField] PlayersTurnTwo playerContr;
    [SerializeField] AlienBossThree player;
    [SerializeField] public int order;
    [SerializeField] GameObject goal; 
    float speed = 2.0f;
    Transform goalPosition;
    public bool atPosition = false;
    public bool playersTurn = false;
    public bool readyToStart;
    void Start()
    {
        goalPosition = goal.GetComponent<Transform>(); 
        readyToStart = playerContr.readyToStart;
    }

    void Update(){
       if(!playerContr.readyToStart) return;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,goalPosition.position,step);
        if(Vector3.Distance(transform.position, goalPosition.position) < 0.001f) atPosition = true;

    }
}
