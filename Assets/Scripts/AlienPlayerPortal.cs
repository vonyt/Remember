using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienPlayerPortal : MonoBehaviour
{
    [SerializeField] Shooter laserBeam;
    [SerializeField] Image healthBar;
    public int health = 3, memoryInd = 0;
    [SerializeField] float speed = 2.0f;
    public GameObject asteroidClicked;
    SpriteRenderer render;
    SpriteRenderer sprite;
    Transform playerPosition;
    public Vector3 asteroidPosition;
    RectTransform healthSize;
    [SerializeField] public GameObject[] asteroidPath = new GameObject[12];
    [SerializeField] public GameObject[] gameBoard = new GameObject[49];
    public bool movePlayer = false;
    Transform healthModifier;
    Rigidbody2D rb;
    bool wasClicked = false;
    public bool hasWon = false;
    public bool failed = false;


    public void damagePlayer(){
        health--;
        Vector3 scale = healthSize.localScale;
        scale.x = scale.x - 0.1f;
        healthSize.localScale = scale;
        if(health == 0){
            //Change game scene to failure screen
        }
    }

    void Awake(){
        playerPosition = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        healthSize = healthBar.GetComponent<RectTransform>();
    }

    public void MoveToAsteroid(Vector3 position){
        asteroidPosition = position;
        if(!movePlayer){
            StartCoroutine(MovingToAsteroid());
        }
    }

    public IEnumerator MovingToAsteroid(){
        movePlayer = true;
        float step = speed * Time.deltaTime;
        Debug.Log("Position going to is: " + asteroidPosition);
        while(Vector3.Distance(transform.position, asteroidPosition) > 0.001f){
        transform.position = Vector3.MoveTowards(transform.position,asteroidPosition,step);
        if(!wasClicked) yield return null;
        yield return null;
        }
        movePlayer = false;
        Debug.Log("Position is at: " + transform.position);
        if(asteroidClicked.CompareTag("finalMemory")) hasWon = true; 
    
        if(asteroidClicked != asteroidPath[memoryInd++]) {
            foreach (var asteroid in gameBoard) {
            sprite = asteroid.GetComponentInChildren<SpriteRenderer>();
            if(sprite !=null) sprite.color = Color.red;
            Debug.Log("Setting failed to true");
            failed = true;
            }
        }
    }


}

