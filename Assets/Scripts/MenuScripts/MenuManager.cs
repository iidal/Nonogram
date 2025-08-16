using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour
{
    int m_numberOfPuzzlePacks = 0; // get pack folder amount / scriptable object amounts etc
    List<int> numberOfPuzzlesInPack = new(); // how many puzzles in each pack, will be packs and the puzzles in them

    public Transform m_packParent;
    public GameObject m_packButtonPrefab;
    public Transform m_puzzlesParent;
    public GameObject m_puzzleButtonPrefab;
    /////
    void Start()
    {
        m_packParent.gameObject.SetActive(false);
        m_puzzlesParent.gameObject.SetActive(false);
        ReadResources();
    }

    public void OnOpenPackMenu()
    {
        m_packParent.gameObject.SetActive(true);
        m_puzzlesParent.gameObject.SetActive(false);

        for (int i = 0; i < m_numberOfPuzzlePacks; i++)
        {
            GameObject packButton = Instantiate(m_packButtonPrefab, m_packParent);
            packButton.GetComponent<PackButtonController>().init_button(this, i);
        }
    }
    public void OnClickPuzzlePack(int puzzlePackId)
    {
        m_packParent.gameObject.SetActive(false);
        m_puzzlesParent.gameObject.SetActive(true);
        // open puzzle view, instantiate buttons for each puzzle in pack
        for (int i = 0; i < numberOfPuzzlesInPack[puzzlePackId]; i++)
        {
            // create button for each puzzle
            Debug.Log("Creating button for Puzzle " + i + " in " + puzzlePackId);
            GameObject puzzleButton = Instantiate(m_puzzleButtonPrefab, m_puzzlesParent);
            puzzleButton.GetComponent<PuzzleButtonController>().init_button(this, i);
        }
    }

    public void OnClickPuzzle(int puzzleId)
    {
        //open puzzle
        Debug.Log("open puzzle " + puzzleId);
    }

    // get here a list of puzzle packs in resources
    public void ReadResources()
    {
        Debug.Log("Reading resources for puzzle packs...");
        
        // this is a placeholder, replace with actual logic to read puzzle packs
        m_numberOfPuzzlePacks = 1; // get pack folder amount / scriptable object amounts etc

        for (int i = 0; i < m_numberOfPuzzlePacks; i++)
        {
            // for each puzzle pack, create configs from jsons/scriptable objects
            numberOfPuzzlesInPack.Add(2);
        }
    }
}
