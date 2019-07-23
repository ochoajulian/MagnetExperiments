using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public PuzzleController puzzleController;

    private void Start()
    {
        puzzleController = FindObjectOfType<PuzzleController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
        }
        else
        {
            if (other.gameObject.tag == "Puzzle")
            {
                puzzleController.PuzzleInteraction(other.gameObject);
            }
            Destroy(gameObject);

        }

    }
}
