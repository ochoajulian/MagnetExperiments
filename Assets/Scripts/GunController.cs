using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int currentGun;
    public GameObject[] guns;
    //Referenced in MTC.cs
    public static bool isMagnetGun;

    bool bButton, aButton;

    // Use this for initialization
    void Start()
    {
        changeGun(0);
        isMagnetGun = true;
    }

    // Update is called once per frame
    void Update()
    {
        bButton = Input.GetButtonDown("Oculus_B");
        aButton = Input.GetButtonDown("Oculus_A");

        //Implemented this way to prevent players from pushing both "X" and "Y" at the same time.
        if (bButton && aButton)
        {
            //Debug.Log("We expected this...");
        }
        else if (bButton)
        {
            changeGun(0);
            isMagnetGun = true;
        }
        else if (aButton)
        {
            changeGun(1);
            isMagnetGun = false;
        }
    }

    public void changeGun(int num)
    {
        currentGun = num;
        for (int i = 0; i < guns.Length; i++)
        {
            if (i == num)
                guns[i].gameObject.SetActive(true);
            else
                guns[i].gameObject.SetActive(false);
        }
    }
}
