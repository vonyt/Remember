using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShooterThree : MonoBehaviour
{
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] BossEnemyControllerTwo enemyContr;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] AudioSource audio;
    private GameObject ammoInstance;
    public Transform ammoSpawnIn;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    int ammoSpeed = 8, enemyIndex = 0;
    //float time = 0f;
   public PlayerEnemyTwo[] bosses = new PlayerEnemyTwo[7];
   public PlayerEnemyTwo[] order = new PlayerEnemyTwo[7];
   public int orderIndex;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            ammoInstance = Instantiate(ammoPrefab,ammoSpawnIn.position,ammoSpawnIn.rotation);
            audio.PlayOneShot(shootingSound);
            sprite = ammoInstance.GetComponent<SpriteRenderer>();
            sprite.color = Color.green;
            rb = ammoInstance.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.up * ammoSpeed;
            AmmoThree ammoEnemy = ammoInstance.GetComponent<AmmoThree>();
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
        PlayerEnemyTwo enemy = other.gameObject.GetComponent<PlayerEnemyTwo>();
        bosses[enemyIndex] = enemy;
        if(enemy == null ) Debug.Log("enemy is null");
        if (enemy) Debug.Log("enemy not null");
        //if (!(enemyContr.bosses[enemyIndex] == other.gameObject)) Debug.Log("Failed");
        //if(enemyIndex == 5) isCorrectPattern();
        isCorrectPattern();
        //other.gameObject.SetActive(false);
        //Destroy(GetComponent<Collider>().gameObject);
        //time = 0;
        enemyIndex++;
    }

    public void isCorrectPattern(){
        if (order[orderIndex] == bosses[orderIndex++] && orderIndex != 7) return;
        if(orderIndex == order.Length) {
            SceneManager.LoadScene("StartScene");
            return;
        }
        SceneManager.LoadScene("QuitGameScene");
        
    }

}
