using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    static BackgroundMusic backTrack;
    [SerializeField] AudioClip music;

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }

}



