using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject ammoPrefab;
    private GameObject ammoInstance;
    public Transform ammoSpawnIn;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    int ammoSpeed = 5;
    float time = 0; 

    void Update(){
        time += Time.deltaTime;
        if(time < 3.0f) return;
        SpawnAmmo();
        time = 0.0f;
    }

    void SpawnAmmo(){
        ammoInstance = Instantiate(ammoPrefab,ammoSpawnIn.position,ammoSpawnIn.rotation);
        sprite = ammoInstance.GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
        rb = ammoInstance.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * ammoSpeed;
    }
}
