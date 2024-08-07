using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] BossEnemyController enemyContr;

    [SerializeField] AudioClip shootingSound;
    [SerializeField] AudioSource audio;
    private GameObject ammoInstance;
    public Transform ammoSpawnIn;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    int ammoSpeed = 8; //enemyIndex = 0;
    //float time = 0f;
   public PlayerEnemy[] bosses = new PlayerEnemy[5];

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            ammoInstance = Instantiate(ammoPrefab,ammoSpawnIn.position,ammoSpawnIn.rotation);
            audio.PlayOneShot(shootingSound);
            sprite = ammoInstance.GetComponent<SpriteRenderer>();
            sprite.color = Color.green;
            rb = ammoInstance.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.up * ammoSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        SpriteRenderer sprite = GetComponent<Collider>().GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
        //while(time > 1.5f) time += Time.deltaTime;
        /*if(!(other.gameObject.CompareTag("PlayerEnemy"))) return;
        PlayerEnemy enemy = other.gameObject.GetComponent<PlayerEnemy>();
        bosses[enemyIndex] = enemy;
        if(enemy == null ) Debug.Log("enemy is null");
        if (enemy) Debug.Log("enemy not null");
        if (!(enemyContr.bosses[enemyIndex] == other.gameObject)) Debug.Log("Failed");
        //if(enemyIndex == 5) isCorrectPattern();
        other.gameObject.SetActive(false);
        //Destroy(GetComponent<Collider>().gameObject);
        time = 0;
        enemyIndex++;*/
    }

}
