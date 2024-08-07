using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackScroll : MonoBehaviour
{
    [SerializeField] RawImage backgroundImage;
    [SerializeField] float x,y;

    // Update is called once per frame
    void Update()
    {
        backgroundImage.uvRect = new Rect(backgroundImage.uvRect.position + new Vector2(x,y) * Time.deltaTime,backgroundImage.uvRect.size);

    }
}
