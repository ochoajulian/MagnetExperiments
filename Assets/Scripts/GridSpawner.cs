using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    //public GameObject[] objectToSpawn;

    public int numObjectsX = 3;
    public int numObjectsY = 3;
    public int numObjectsZ = 3;

    public Vector3 objectSpacing = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < numObjectsX; x++)
        {
            for (int y = 0; y < numObjectsY; y++)
            {
                for (int z = 0; z < numObjectsZ; z++)
                {
                    //float randomNumber = Random.Range(0.0f, objectToSpawn.Length - 0.1f);

                    Instantiate(objectToSpawn/*[(int)randomNumber]*/, transform.position + transform.right * x * objectSpacing.x
                                                                  + transform.up * y * objectSpacing.y
                                                                  + transform.forward * z * objectSpacing.z,
                                                                  Quaternion.identity);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
