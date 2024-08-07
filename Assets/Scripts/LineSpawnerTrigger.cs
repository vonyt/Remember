using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawnerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Ammo")) {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player")){
            AlienPlayerTwo player = other.GetComponent<AlienPlayerTwo>();
            player.damagePlayer();
            Destroy(gameObject);
        }
    }
}
