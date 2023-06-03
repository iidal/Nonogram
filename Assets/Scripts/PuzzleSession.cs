using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSession : MonoBehaviour
{    
    public void SwitchMarkMode()
    {
        if (PuzzleBlackboard.IsMarkingMode())
        {
            Debug.Log("set marking mode false");
            PuzzleBlackboard.SetMarkModeOn(false);
        }
        else
        {
            Debug.Log("set marking mode true");
            PuzzleBlackboard.SetMarkModeOn(true);
        }
    }
}
