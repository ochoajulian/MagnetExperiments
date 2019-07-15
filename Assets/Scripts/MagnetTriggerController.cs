using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTriggerController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Magnet rightHand;
    public MeshRenderer rayGunModel;
    public List<Material> poleMaterials = new List<Material>();
    public float maxForce = 20f;

    private float rightTrigger;
    private bool northPole = true;
    private bool leftStickClick;


    // Use this for initialization
    void Start()
    {
        NorthPole();
    }

    // Update is called once per frame
    void Update()
    {
        //On Right Trigger, multiply rightTrigger value by maxForce.
        rightTrigger = Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger");
        rightHand.MagnetForce = maxForce * rightTrigger;

        //On Left Stick click, change magnet/material of Ray Gun to other pole.      
        leftStickClick = Input.GetButtonDown("Oculus_CrossPlatform_PrimaryThumbstick");
        if (leftStickClick && northPole)
        {
            SouthPole();
        }
        else if (leftStickClick && !northPole)
        {
            NorthPole();
        }
    }

    void NorthPole()
    {
        //Change Pole
        northPole = true;
        rightHand.MagneticPole = Magnet.Pole.North;
        //Debug.Log("North Pole");
        //Change material
        rayGunModel.material = poleMaterials[0];

    }

    void SouthPole()
    {
        //Change Pole
        northPole = false;
        rightHand.MagneticPole = Magnet.Pole.South;
        //Debug.Log("South Pole");
        //Change Material
        rayGunModel.material = poleMaterials[1];

    }
}
