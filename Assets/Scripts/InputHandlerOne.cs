using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandlerOne : MonoBehaviour
{
    [SerializeField] AlienPlayer player;

    void FixedUpdate(){
        Vector3 move = new Vector3(0,0,0);

        if(Input.GetKey(KeyCode.W)){
            move += new Vector3(0,1,0);
        }
        if(Input.GetKey(KeyCode.A)){
            move += new Vector3(-1,0,0);
        }
        if(Input.GetKey(KeyCode.D)){
            move += new Vector3(1,0,0);
        }
        if(Input.GetKey(KeyCode.S)){
            move += new Vector3(0,-1,0);
        }
        player.Move(move);
    }
}
