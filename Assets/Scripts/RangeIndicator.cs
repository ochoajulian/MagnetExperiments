using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Sprite[] rangeImages = { };
    //public Material[] rangeMaterials = { };

    bool xButton, yButton;
    int rangeCounter = 1;
    SpriteRenderer spriteRenderer;
    Color genericColor = Color.white;

    // Use this for initialization
    void Start()
    {
        rangeCounter = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        genericColor.a = .5f;
        spriteRenderer.color = genericColor;

    }

    // Update is called once per frame
    void Update()
    {
        xButton = Input.GetButtonDown("Oculus_X");
        yButton = Input.GetButtonDown("Oculus_Y");

        //Implemented this way to prevent players from pushing both "X" and "Y" at the same time.
        if (yButton && xButton)
        {
            //Debug.Log("We expected this...");
        }
        else if (yButton)
        {
            //Debug.Log("Y Button Pressed");
            if (rangeCounter < 3)
            {
                rangeCounter++;
            }
        }
        else if (xButton)
        {
            if (rangeCounter > 0)
            {
                rangeCounter--;
            }
        }
        spriteRenderer.sprite = rangeImages[rangeCounter];
        //spriteRenderer.material = rangeMaterials[rangeCounter];
        //GetComponent<SpriteRenderer>().color.a.
    }
}
