using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1BossEnemy : MonoBehaviour
{
    [SerializeField] GameObject goal; 
    [SerializeField] public int order;
    float speed = 2f;
    Transform goalPosition;
    public bool atPosition = false;

    void Awake(){
        goalPosition = goal.GetComponent<Transform>(); 
    }

    void Update(){
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,goalPosition.position,step);
        if(Vector3.Distance(transform.position, goalPosition.position) < 0.001f) atPosition = true;
    }

}

