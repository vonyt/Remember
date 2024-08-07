using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoThree : MonoBehaviour
{
    //[SerializeField] GameObject playerObject;
    Color originalSprite;
    SpriteRenderer playerSprite;
    float lifetime = 10.0f;
    bool doesExist;

     void Start(){
        doesExist = true;
        StartCoroutine(DestroyAmmo());
    }

    IEnumerator DestroyAmmo(){
        yield return new WaitForSeconds(lifetime);
        if(!doesExist) yield break;
        doesExist = false;
        Destroy(gameObject);
    }

    void OnCollisionExit2D(Collision2D collision){
        if(!collision.gameObject.CompareTag("Player")) return;
        playerSprite.color = originalSprite;
        if(!doesExist) return;
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(!doesExist) return;
        if(collision.gameObject.CompareTag("Ammo")) Destroy(gameObject);
        if(!collision.gameObject.CompareTag("Player")) return;
        //player = collision.GameObject.GetComponent<AlienPlayer>(); 
        AlienPlayerThree player = collision.gameObject.GetComponent<AlienPlayerThree>();
        player.damagePlayer();
        playerSprite = player.GetComponent<SpriteRenderer>();
        originalSprite = playerSprite.color;
        playerSprite.color = Color.red;
        Destroy(gameObject);
    }

}
