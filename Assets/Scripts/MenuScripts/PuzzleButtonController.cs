using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtonController : MonoBehaviour
{
    MenuManager m_menuManager;
    int m_puzzleId; // poc
    public void init_button(MenuManager manager, int puzzleId)
    {
        m_menuManager = manager;
        m_puzzleId = puzzleId;
    }
    public void OnButtonClick()
    {
        m_menuManager.OnClickPuzzle(m_puzzleId);
    }
}
