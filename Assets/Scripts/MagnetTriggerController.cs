using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTriggerController : MonoBehaviour
{

    public Magnet leftHand, rightHand;
    private float rightTrigger, leftTrigger;
    public float maxForce = 10f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rightTrigger = Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger");
        leftTrigger = Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger");

        leftHand.MagnetForce = maxForce * leftTrigger;
        rightHand.MagnetForce = maxForce * rightTrigger;
    }
}
