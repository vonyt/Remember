using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawn : MonoBehaviour
{
    [SerializeField] GameObject portalPrefab;
    [SerializeField] AlienPlayerTwo player;
    [SerializeField] FaderTwo script;
    
    private GameObject portalInstance;
    public Transform portalSpawn;
    int portalSpeed = 2;
    //float time = 0;

    Rigidbody2D rb;
    //bool portalCalled = false;

    void Update(){
        if(!PointsAccessor.partOneSpawned && PointsAccessor.points == 3){
            SpawnPortal();
            PointsAccessor.partOneSpawned = true;
            //portalCalled = true;
        }
    }

        void SpawnPortal(){
        int xSpawn = Random.Range(-18,18);
        Vector3 randomSpawn = new Vector3(xSpawn,portalSpawn.position.y,portalSpawn.position.z);
        portalInstance = Instantiate(portalPrefab, randomSpawn,portalSpawn.rotation);
        rb = portalInstance.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * portalSpeed;
        portalController contr = portalInstance.GetComponent<portalController>();
        contr.script = script;
    }

}
