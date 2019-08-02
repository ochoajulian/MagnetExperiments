using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerController : MonoBehaviour
{
    public GameObject Light;
    public float timer;
    public static bool isCubeHit;
    bool startCoroutine;

    // Use this for initialization
    void Start()
    {
        startCoroutine = true;
        isCubeHit = false;
    }

    // Update is called once per frame
    IEnumerator FlickeringLight()
    {
        Light.SetActive(true);
        timer = Random.Range(0.1f, .5f);
        yield return new WaitForSeconds(timer);
        Light.SetActive(false);
        timer = Random.Range(0.1f, .5f);
        yield return new WaitForSeconds(timer);
        StartCoroutine(FlickeringLight());
    }

    private void Update()
    {
        //if (isCubeHit == true)
        //{
        //    Debug.Log("Stopped coroutine");
        //    StopCoroutine(FlickeringLight());
        //}
        //if(isCubeHit == false)
        //{
        //    StartCoroutine(FlickeringLight());
        //    Debug.Log("Started coroutine");
        //}

        //if (isCubeHit == false)
        //{
        //    if (startCoroutine)
        //    {
        //        StartCoroutine(FlickeringLight());
        //    }
        //    else
        //    {
        //        StopCoroutine(FlickeringLight());
        //    }
        //    startCoroutine = !startCoroutine;
        //}
        //
        //if(isCubeHit == true)
        //{
        //    StopCoroutine(FlickeringLight());
        //}
    }
}
