using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SecondPathController : MonoBehaviour
{
    [SerializeField] SecondAlienPlayerPortal player;
    [SerializeField] public GameObject[] asteroidPath = new GameObject[17];
    [SerializeField] SpriteRenderer ogSprite;
    SecondAsteroidCollision didCollide;
    Vector3 asteroidPosition;
    SpriteRenderer sprite;
    SpriteRenderer showSprite;
    Color ogColor;
    //bool collided = false;
    int i;

    // Start is called before the first frame update
    public void MakePath(GameObject uiElement)
    {
        didCollide = uiElement.GetComponent<SecondAsteroidCollision>();
        if(didCollide == null) Debug.Log("colliding checkers null");
        didCollide.clicked = true;
        ogColor = ogSprite.color;
        //helped
        RectTransform rectTransform = uiElement.GetComponent<RectTransform>();
        Vector3 asteroidPosition = rectTransform.position;
        asteroidPosition = rectTransform.TransformPoint(rectTransform.rect.center);
        StartCoroutine(LightPath(uiElement));
        player.MoveToAsteroid(asteroidPosition);
       // if(!collided) return;
       // uiElement.SetActive(false);
       // Debug.Log("Position to go to is: " + asteroidPosition);
    }

    /*void OnCollisionEnter2D(Collision2D collision){
        collision.gameObject.SetActive(false);
        if(collision.gameObject.CompareTag("Player")) {
            collided = true;
            Debug.Log("collided w/ player");
        }
    }*/

        IEnumerator LightPath(GameObject button){
        sprite = button.GetComponentInChildren<SpriteRenderer>();
        sprite.color = Color.red;
        yield return new WaitForSeconds(1.0f);
    }

    void Start(){
        StartCoroutine(ShowPath());
    }

    IEnumerator ShowPath(){
        //helped
        for(int j = 0; j < 21; j++){
            SpriteRenderer[] showSprites = asteroidPath[j].GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer sprite in showSprites){
                sprite.color = Color.red;
            }
            yield return new WaitForSeconds(1.0f);
        }
        yield return new WaitForSeconds(2.0f);
        for(int j= 0; j < 21; j++){
        SpriteRenderer[] showSprites = asteroidPath[j].GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer sprite in showSprites){
                sprite.color = ogSprite.color;
            }
        }
    }

}
