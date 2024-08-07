using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTwo : MonoBehaviour
{
    AlienPlayerTwo player;
     /*void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            player = collision.gameObject.GetComponent<AlienPlayer>();
            player.points++;
        }
     }*/

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            player = other.gameObject.GetComponent<AlienPlayerTwo>();
            player.pointCollected();
            Destroy(gameObject);
        }
    }

}
