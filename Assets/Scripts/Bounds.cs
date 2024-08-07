using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D collision){
    if(!collision.gameObject.CompareTag("Player")) Destroy(collision.gameObject);
    if(collision.gameObject.CompareTag("Ammo")) Destroy(collision.gameObject);
   }
}
