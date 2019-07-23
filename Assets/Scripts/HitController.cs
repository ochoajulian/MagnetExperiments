using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public static string correctOrder = "XIT";
    public static string playerCode = "";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerCode);
    }

    private void OnTriggerEnter(Collider other)
    {
        playerCode += gameObject.name;
    }
}
