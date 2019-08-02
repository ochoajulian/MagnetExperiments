using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public List<GameObject> puzzleElements = new List<GameObject>();
    public float puzzleTimer = 10.0f;
    public GameObject ExitDoor;

    private List<GameObject> playerSelection = new List<GameObject>();
    private bool startTimer = false;
    private float resetTimerValue;
    private int puzzleCounter = 0;
    private int resultCounter = 0;
    // Use this for initialization
    void Start()
    {
        resetTimerValue = puzzleTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            puzzleTimer -= Time.deltaTime;
        }
        if (puzzleTimer <= 0.0f)
        {
            StartCoroutine(ResetPuzzle());
        }
        if (puzzleCounter == 3)
        {
            startTimer = false;

            //Power up/open door
            Debug.Log("Unlocked Door");
            //Stop the named clip
            FindObjectOfType<SFXManager>().Stop("PuzzleTimer");
            ExitDoor.SetActive(false);

            //for (int i = 0; i < 3; i++)
            //{
            //    if (playerSelection[i] != puzzleElements[i])
            //    {
            //        StartCoroutine(ResetPuzzle());
            //    }
            //    else
            //    {
            //        resultCounter++;
            //    }
            //
            //}
            //if (resultCounter == 3)
            //{
            //    startTimer = false;
            //
            //    //Power up/open door
            //    Debug.Log("Unlocked Door");
            //    ExitDoor.SetActive(false);
            //
            //}
        }
    }

    private IEnumerator ResetPuzzle()
    {
        puzzleCounter = 0;
        //Stop the named clip
        FindObjectOfType<SFXManager>().Stop("PuzzleTimer");
        startTimer = false;
        foreach (GameObject go in playerSelection)
        {
            go.GetComponentInChildren<Light>().enabled = false;
            LightFlickerController.isCubeHit = true;
        }
        yield return new WaitForSeconds(0.2f);
        playerSelection.Clear();
    }



    public void PuzzleInteraction(GameObject puzzlePiece)
    {
        if (!startTimer)
        {
            puzzleTimer = resetTimerValue;
            startTimer = true;
            FindObjectOfType<SFXManager>().Play("PuzzleTimer");
            Debug.Log("Playing cube");
        }
        if (!playerSelection.Contains(puzzlePiece))
        {
            playerSelection.Add(puzzlePiece);
            puzzlePiece.GetComponentInChildren<Light>().enabled = true;
            //Though the LFC script turns off, the light still flickers...
            //puzzlePiece.GetComponent<LightFlickerController>().enabled = false;
            //
            LightFlickerController.isCubeHit = true;
            puzzleCounter++;
        }
    }
}
