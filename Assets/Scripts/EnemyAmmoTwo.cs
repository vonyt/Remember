using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoTwo : MonoBehaviour
{
    //[SerializeField] GameObject playerObject;
    Color originalColor;
    SpriteRenderer playerSprite;
    float lifetime = 7.0f;
    bool doesExist;

     void Start(){
        doesExist = true;
        StartCoroutine(DestroyAmmo());
    }

    IEnumerator DestroyAmmo(){
        yield return new WaitForSeconds(lifetime);
        if(!doesExist) yield break;
        doesExist = false;
        //Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(!doesExist) return;
        //if(collision.gameObject.CompareTag("Ammo")) Destroy(gameObject);
        if(!collision.gameObject.CompareTag("Player")) return;
        //player = collision.GameObject.GetComponent<AlienPlayer>(); 
        AlienPlayerTwo player = collision.gameObject.GetComponent<AlienPlayerTwo>();
        if(player == null) Debug.Log("suckers null");
        player.damagePlayer();
        playerSprite = collision.gameObject.GetComponent<SpriteRenderer>();
        Destroy(gameObject);
    }

}
