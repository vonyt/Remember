using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAsteroidCollision : MonoBehaviour
{
    [SerializeField] SecondAlienPlayerPortal player;
    public bool collided = false;
    public bool clicked = false;
    SpriteRenderer sprite;
    float timer = 0f;
            void OnCollisionEnter2D(Collision2D collision){
            if(!clicked) return;
            player.asteroidClicked = gameObject;
            sprite = GetComponentInChildren<SpriteRenderer>();
            sprite.color = Color.red;
            while(timer < 1.0f) timer += Time.deltaTime;
            gameObject.SetActive(false);
            if(collision.gameObject.CompareTag("Player")) {
            collided = true;
            Debug.Log("collided w/ player");
            //gameObject.SetActive(false);
        }
    }
}
