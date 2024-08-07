using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject enemyInstance;
    public Transform spawnIn;
    int enemySpeed = 2;
    float time = 0;

    Rigidbody2D rb;

    void Start(){
        SpawnEnemy();
    }

    void Update(){
        time += Time.deltaTime;
        if(time < 1.5f) return;
        SpawnEnemy();
        time = 0.0f;

    }

    void SpawnEnemy(){
        int xSpawn = Random.Range(-18,18);
        Vector3 randomSpawn = new Vector3(xSpawn,spawnIn.position.y,spawnIn.position.z);
        enemyInstance = Instantiate(enemyPrefab, randomSpawn,spawnIn.rotation);
        rb = enemyInstance.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * enemySpeed;
    }

}
