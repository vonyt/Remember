using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    [SerializeField] GameObject pointPrefab;
    private GameObject pointInstance;
    public Transform spawnIn;
    int pointSpeed = 5;
    int spawnedPoints = 0;
    float time = 0;

    Rigidbody2D rb;

    void Start(){
        SpawnPoint();
    }

    void Update(){
        time += Time.deltaTime;
        if(time < 3.0f) return;
        SpawnPoint();
        time = 0.0f;

        /*if(PointsAccessor.points != spawnedPoints){
            StartCoroutine(MatchPoints());
        }*/

    }

    /*IEnumerator MatchPoints(){
        while (PointsAccessor.points > spawnedPoints){
            SpawnPoint();
        }
        yield return null;
    }*/

    void SpawnPoint(){
        int xSpawn = Random.Range(-18,18);
        spawnedPoints++;
        Vector3 randomSpawn = new Vector3(xSpawn,spawnIn.position.y,spawnIn.position.z);
        pointInstance = Instantiate(pointPrefab, randomSpawn,spawnIn.rotation);
        rb = pointInstance.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * pointSpeed;
    }

}
