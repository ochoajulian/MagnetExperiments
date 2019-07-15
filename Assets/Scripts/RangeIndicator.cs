using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    int rangeCounter;
    bool xButton, yButton;

    // Use this for initialization
    void Start()
    {
        rangeCounter = 2;
    }

    // Update is called once per frame
    void Update()
    {
        xButton = Input.GetButtonDown("Oculus_X");
        yButton = Input.GetButtonDown("Oculus_Y");
        if(yButton && xButton)
        {

        }
        else if (yButton)
        {
            Debug.Log("Y Button Pressed");
        }
        else if (xButton)
        {
            Debug.Log("X Button Pressed");
        }
    }
}
