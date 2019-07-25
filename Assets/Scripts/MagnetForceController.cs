using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetForceController : MonoBehaviour
{
    //Reference to 1/2 of bridge above this magnet pad
    public GameObject bridge;

    // Use this for initialization
    void Start()
    {
        bridge.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magnet")
        {
            Debug.Log(other.name + other.GetComponentInChildren<Magnet>().MagneticPole + "Magnet entered trigger!");
            other.GetComponentInChildren<Magnet>().MagnetForce = 10f;
            bridge.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponentInChildren<Magnet>().MagnetForce = 0f;
        bridge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
