using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AlienPlayer1 : MonoBehaviour
{
    [SerializeField] Shooter laserBeam;
    [SerializeField] Image healthBar;
    [SerializeField] GameObject pointPrefab;
    [SerializeField] TextMeshProUGUI pointCount;
    [SerializeField] Sprite pointSprite;
    public Transform pointSpawnIn;
    public int health = 5;
    public int points = 0;
    [SerializeField] float speed = 2.0f;
    [SerializeField] Sprite frontFacing;
    [SerializeField] Sprite backFacing;
    SpriteRenderer render;
    RectTransform healthSize;


    Transform healthModifier;
    bool collectedPoint;
    Rigidbody2D rb;

    public void pointCollected(){
        GameObject pointInstance = Instantiate(pointPrefab, pointSpawnIn.position,pointSpawnIn.rotation);
        pointSpawnIn.position = new Vector3(pointSpawnIn.position.x+1f,pointSpawnIn.position.y,pointSpawnIn.position.z);
        points++;
    }

    void Update(){
        pointCount.text = points + "";
        if(points == 10) SceneManager.LoadScene("LV1BossScene");
    }

    public void damagePlayer(){
        health--;
        //healthModifier = healthBar.GetComponent<Transform>();
        //healthModifier = new Transform(healthModifer);
        Vector3 scale = healthSize.localScale;
        scale.x = scale.x - 0.1f;
        healthSize.localScale = scale;
        if(health == 0){
            SceneManager.LoadScene("QuitGameScene");
        }
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

