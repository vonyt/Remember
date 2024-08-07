using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShooterTwo : MonoBehaviour
{
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] BossEnemyController enemyContr;
    [SerializeField] BossOneFader script;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] AudioSource audio;
    private GameObject ammoInstance;
    public Transform ammoSpawnIn;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    int ammoSpeed = 8, enemyIndex = 0;
   public PlayerEnemy[] bosses = new PlayerEnemy[5];
   public PlayerEnemy[] order = new PlayerEnemy[5];
   public int orderIndex;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            ammoInstance = Instantiate(ammoPrefab,ammoSpawnIn.position,ammoSpawnIn.rotation);
            audio.PlayOneShot(shootingSound);
            sprite = ammoInstance.GetComponent<SpriteRenderer>();
            sprite.color = Color.green;
            rb = ammoInstance.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.up * ammoSpeed;
            AmmoTwo ammoEnemy = ammoInstance.GetComponent<AmmoTwo>();
            ammoEnemy.shooter = this;
            ammoEnemy.enemyContr = enemyContr;
            ammoEnemy.correctOrder = enemyContr.correctOrder;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        SpriteRenderer sprite = GetComponent<Collider>().GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
        //while(time > 1.5f) time += Time.deltaTime;
        if(!(other.gameObject.CompareTag("PlayerEnemy"))) return;
        PlayerEnemy enemy = other.gameObject.GetComponent<PlayerEnemy>();
        bosses[enemyIndex] = enemy;
        if(enemy == null ) Debug.Log("enemy is null");
        //if (!(enemyContr.bosses[enemyIndex] == other.gameObject)) Debug.Log("Failed");
        //if(enemyIndex == 5) isCorrectPattern();
        isCorrectPattern();
        //other.gameObject.SetActive(false);
        //Destroy(GetComponent<Collider>().gameObject);
        enemyIndex++;
    }

    public void isCorrectPattern(){
        if (order[orderIndex] == bosses[orderIndex++] && orderIndex != 5) return;
        if(orderIndex == order.Length) {
            Debug.Log("Calling winner fader");
            script.fadingOut();
            return;
        }
        Debug.Log("Calling loser fader");
        script.LoserFadingOut();
    }

}
