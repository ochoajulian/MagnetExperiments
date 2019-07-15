using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject northCharge;
    public GameObject southCharge;    
    float triggerPullPercentage = .98f;

    [Header("Set Dynamically")]
    [SerializeField] bool isTriggerPulled;
    private float rightTrigger;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rightTrigger = Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger");

        //On RT, anywhere from 10% to 90%, then release, spawn a magnet ball.
        if (rightTrigger >= triggerPullPercentage && !isTriggerPulled)
        {
            GameObject northBullet = Instantiate(northCharge, northCharge.transform.position, transform.rotation);
            northBullet.transform.parent = this.transform;
            northBullet.transform.localScale = Vector3.one;
            isTriggerPulled = true;

        }
        if (rightTrigger < triggerPullPercentage)
        {
            isTriggerPulled = false;
        }
    }
}
