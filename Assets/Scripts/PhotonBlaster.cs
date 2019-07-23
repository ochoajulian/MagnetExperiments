using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonBlaster : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float triggerPercentage = .75f;
    public AudioClip shootingAudio;


    private float rightTrigger;
    private bool isPressed;
    private bool isVibrating = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rightTrigger = Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger");
        //This fires more like a machine gun than what we're after...
        if (rightTrigger >= triggerPercentage && !isPressed)
        {
            isPressed = true;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody>().velocity = -transform.forward * projectileSpeed;
            VibrationManager.singleton.TriggerVibration(shootingAudio, OVRInput.Controller.RTouch);
        }
        else if (rightTrigger < triggerPercentage)
        {
            isPressed = false;
            //OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
        }




    }

    /*private IEnumerator Vibration()
    {
        
        if(isVibrating == false)
        {
            OVRInput.SetControllerVibration(.25f, .25f, OVRInput.Controller.RTouch); 
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody>().velocity = -transform.forward * projectileSpeed;
            isVibrating = true;

        }
        yield return new WaitForSeconds(0.5f);
        isVibrating = false;

    }
    */
}
