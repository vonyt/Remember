using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienPlayerLevelTwo : MonoBehaviour
{
    [SerializeField] ShooterTwo laserBeam;
    [SerializeField] float speed = 2.0f;
    [SerializeField] Sprite backFacing;
    [SerializeField] PlayersTurn textController;
    SpriteRenderer render;
    RectTransform healthSize;

    Transform healthModifier;
    bool collectedPoint;
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    void Update(){
        /*if(textController.readyToStart) {
            laserBeam.gameObject.SetActive(true);
            //gameObject.SetActive(true);
        }*/
    }

    public void Move(Vector3 distance){
        distance *= speed;

        if(distance.x < 0){
            render.sprite = backFacing;
        }
        if(distance.x > 0){
            render.sprite = backFacing;
        }

        rb.velocity = distance; //+ new Vector3(0,rb.velocity.y,0);
    }
}

