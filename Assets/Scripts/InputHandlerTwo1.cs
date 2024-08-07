using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandlerTwo1 : MonoBehaviour
{
    [SerializeField] AlienBossThree player;

    void FixedUpdate(){
        Vector3 move = new Vector3(0,0,0);

        if(Input.GetKey(KeyCode.A)){
            move += new Vector3(-1,0,0);
        }
        if(Input.GetKey(KeyCode.D)){
            move += new Vector3(1,0,0);
        }
        player.Move(move);
    }
}
