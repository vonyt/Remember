using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ammo : MonoBehaviour
{
    AlienPlayer player;
    SpriteRenderer ammoSprite;
    public BossEnemyController enemyContr;
    public GameObject[] correctOrder = new GameObject[5];
    //int enemyIndex = 0;
    float lifetime = 10.0f;
    bool doesExist;

    public bool doesAmmoExist(){
        return doesExist;
    }

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

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Point")) return;
        if(collision.gameObject.CompareTag("Player")) return;
        if(collision.gameObject.CompareTag("Bound")) return;
        /*if(collision.gameObject.CompareTag("PlayerEnemy")){
        PlayerEnemy enemy = collision.gameObject.GetComponent<PlayerEnemy>();
        if(enemy == null ) Debug.Log("enemy is null");
        if (enemy) Debug.Log("enemy not null");
        BossEnemyController controller = enemyContr.GetComponent<BossEnemyController>();
        
        if (!(correctOrder[enemyIndex] == collision.gameObject)) SceneManager.LoadScene("LevelOneScene");
        collision.gameObject.SetActive(false);
        enemyIndex++;
        }*/
        if(collision.gameObject) Destroy(collision.gameObject);
        doesExist = false;
        Destroy(gameObject);
    
    }


}
