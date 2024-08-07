using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    AlienPlayer player;
     /*void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            player = collision.gameObject.GetComponent<AlienPlayer>();
            player.points++;
        }
     }*/

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            player = other.gameObject.GetComponent<AlienPlayer>();
            player.pointCollected();
            Destroy(gameObject);
        }
    }

}
