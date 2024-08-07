using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AlienPlayerTwo : MonoBehaviour
{
    [SerializeField] Shooter laserBeam;
    [SerializeField] Image healthBar;
    [SerializeField] LineOneSpawn lineSpawn;
    [SerializeField] GameObject pointPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] TextMeshProUGUI pointCount;
    [SerializeField] Sprite pointSprite;
    [SerializeField] AudioClip pointCollect;
    [SerializeField] AudioSource audio;
    public Transform pointSpawnIn;

    public int health = 5;
    [SerializeField] float speed = 2.0f;
    [SerializeField] Sprite frontFacing;
    [SerializeField] Sprite backFacing;
    SpriteRenderer render;
    RectTransform healthSize;
    bool hurting = false;

    //bool lineSpawnCalled = false;
    Transform healthModifier;
    bool collectedPoint;
    int pointsShowing = 0;
    Rigidbody2D rb,rb2;

    public void pointCollected(){
        audio.PlayOneShot(pointCollect);
        pointsShowing++;
        GameObject pointInstance = Instantiate(pointPrefab, pointSpawnIn.position,pointSpawnIn.rotation);
        pointSpawnIn.position = new Vector3(pointSpawnIn.position.x+1f,pointSpawnIn.position.y,pointSpawnIn.position.z);
       PointsAccessor.points++;
    }

    void Update(){
        pointCount.text = PointsAccessor.points+ "";
        //if(PointsAccessor.points > pointsShowing) pointCollected();
       // if(PointsAccessor.points == 15) SceneManager.LoadScene("LV1BossScene");
    }


    public void damagePlayer(){
        health--;
        //healthModifier = healthBar.GetComponent<Transform>();
        //healthModifier = new Transform(healthModifer);
        Vector3 scale = healthSize.localScale;
        scale.x = scale.x - 0.1f;
        healthSize.localScale = scale;
        
        if(!hurting) {
            hurting = true;
            StartCoroutine(playerHurt());
        }
        if(health == 0){
            SceneManager.LoadScene("QuitGameScene");
        }
        
    }

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.CompareTag("Enemy")){
            damagePlayer();
            Destroy(collider.gameObject);
        }
    }

    IEnumerator playerHurt(){
        Color originalColor = render.color;
        render.color = Color.red;
        Debug.Log("Turning red");
        yield return new WaitForSeconds(.25f);
        render.color = originalColor;
        hurting = false;
    }

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        healthSize = healthBar.GetComponent<RectTransform>();
    }

    public void Move(Vector3 distance){
        distance *= speed;

        if(distance.y < 0){
            render.sprite = backFacing;
        }
        if(distance.y > 0){
            render.sprite = frontFacing;
        }

        rb.velocity = distance; //+ new Vector3(0,rb.velocity.y,0);
    }
}

