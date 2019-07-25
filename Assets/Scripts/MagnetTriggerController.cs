using System;
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
    public Transform raycastOrigin; // using the gun as the origin for Raycasting
    public AudioClip shootingAudio;
    //public LineRenderer line;

    private float rightTrigger;
    private bool northPole = true;
    private bool leftStickClick;

    private List<GameObject> magneticObjects = new List<GameObject>(); //Using to temporarily store which block has been raycasting

    // Use this for initialization
    void Start()
    {
        NorthPole();
        //line = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask1 = 1 << 9;
        int layerMask2 = 1 << 10;

        int finalMask = layerMask1 | layerMask2;

        // This would cast rays only against colliders in layer 8.
        //On Right Trigger, multiply rightTrigger value by maxForce.
        rightTrigger = Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger");
        rightHand.MagnetForce = maxForce * rightTrigger;

        if (rightHand.MagnetForce > 0.2f)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            //If loop will only be true when hit objects on our layers.
            if (Physics.Raycast(raycastOrigin.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, finalMask))
            {
                Debug.Log("Raycasting");
                Debug.DrawRay(raycastOrigin.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if (hit.collider.tag == "Magnet")
                {

                    Debug.Log("Did Hit");
                    Debug.Log(hit.collider.gameObject.name);

                    if (!hit.collider.gameObject.GetComponentInChildren<Magnet>().Selected)
                    {
                        hit.collider.gameObject.GetComponentInChildren<Magnet>().Selected = true;
                        hit.collider.gameObject.GetComponentInChildren<Magnet>().MagnetForce = 5;
                        //Add this Magnet GameObject to magneticObjects List. 
                        magneticObjects.Add(hit.collider.gameObject);

                        //Play the named clip and access it from the SFXManager class
                        FindObjectOfType<SFXManager>().Play("MagnetGun");
                    }
                    //Debug.Log(magneticObjects[0]);
                    //line.SetPosition(0, raycastOrigin.position);
                    //line.SetPosition(1, hit.point);
                }
            }

        }
        else
        {
            //A
            for (int i = 0; i < magneticObjects.ToArray().Length; i++)
            {
                magneticObjects[i].GetComponentInChildren<Magnet>().Selected = false;
                //Gives problems when OnTriggerEnter is called in MagnetForceController.cs...
                magneticObjects[i].GetComponentInChildren<Magnet>().MagnetForce = 0;
                magneticObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                //Remove this Magnet GameObject from magneticObjects List. 
                magneticObjects.Remove(magneticObjects[i]);
                //Stop Audio Source(MagnetGun)
                FindObjectOfType<SFXManager>().Stop("MagnetGun");
            }
        }


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

   private void MagnetBeam()
    {
        
    }

}
