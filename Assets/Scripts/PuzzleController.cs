using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public List<GameObject> puzzleElements = new List<GameObject>();
    public float puzzleTimer = 10.0f;

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
            for (int i = 0; i < 3; i++)
            {
                if (playerSelection[i] != puzzleElements[i])
                {
                    StartCoroutine(ResetPuzzle());
                }
                else
                {
                    resultCounter++;
                }
                
            }
            if (resultCounter == 3)
            {
                startTimer = false;

                //Power up/open door
                Debug.Log("Unlocked Door");
            }
        }
    }

    private IEnumerator ResetPuzzle()
    {
        puzzleCounter = 0;
        startTimer = false;
        foreach (GameObject go in playerSelection)
        {
            go.GetComponentInChildren<Light>().enabled = false;
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
        }
        if (!playerSelection.Contains(puzzlePiece))
        {
            playerSelection.Add(puzzlePiece);
            puzzlePiece.GetComponentInChildren<Light>().enabled = true;
            puzzleCounter++;
        }
    }
}
