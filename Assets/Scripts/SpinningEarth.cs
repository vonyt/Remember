using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningEarth : MonoBehaviour
{
    [SerializeField] Sprite first;
    [SerializeField] Sprite second;
    bool spin = true;
    

    // Update is called once per frame
    void Update()
    {
        if(spin) StartCoroutine(Spin());
    }
    IEnumerator Spin(){
        spin = false;
        yield return new WaitForSeconds(.5f);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite.sprite == first) {
            sprite.sprite = second;
        } else {
            sprite.sprite = first;
        }
        spin = true;
    }
}
