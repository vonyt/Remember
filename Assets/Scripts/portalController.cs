using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class portalController : MonoBehaviour
{
    public FaderTwo script;
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")) {
            script.PortalFade();
        }
    }
}
