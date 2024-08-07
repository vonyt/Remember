using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmmoThree : MonoBehaviour
{
    AlienPlayerThree player;
    SpriteRenderer ammoSprite;
    public BossEnemyControllerTwo enemyContr;
    public GameObject[] correctOrder = new GameObject[5];
    public ShooterThree shooter;
    //int enemyIndex = 0;
    float lifetime = 7.0f;
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
        if(collision.gameObject.CompareTag("bossenemy")){
        PlayerEnemy enemy = collision.gameObject.GetComponent<PlayerEnemy>();
        if(enemy == null ) Debug.Log("enemy is null");
        if (enemy) Debug.Log("enemy not null");
        BossEnemyController controller = enemyContr.GetComponent<BossEnemyController>();
        shooter.order[shooter.orderIndex] = collision.gameObject.GetComponent<PlayerEnemyTwo>();
        shooter.isCorrectPattern();
        //if (!(correctOrder[enemyIndex++] == collision.gameObject)) SceneManager.LoadScene("LevelOneScene");
        collision.gameObject.SetActive(false);
        }
        Debug.Log("Collided w/ enemy");
        //Destroy(collision.gameObject);
        doesExist = false;
        Destroy(gameObject);
    
    }


}
