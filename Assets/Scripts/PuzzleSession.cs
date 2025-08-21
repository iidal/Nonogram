using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PuzzleSession : MonoBehaviour
{
    public BoardCreator m_board_creator;
    public EndViewDialog m_endViewDialog;
    //test stuff
    //5
    bool[,] board = { { false, false, true, false, false }, { true, true, true, true, true }, { false, false, true, false, false }, { false, false, true, false, false }, { false, false, true, true, false } };
    int m_board_row_count = 5;
    int m_board_column_count = 5;

    

    //////////////////////////////////////////////////////////////

    //// MARK MODE BUTTON
    public Image img_mode_button_gfx;
    public Sprite img_box_filled;
    public Sprite img_box_crossed;

    /// LIVES
    private const int m_max_lives = 3;
    private int m_current_lives;
    [SerializeField] Image[] img_lives = new Image[3];
    [SerializeField] Sprite img_life_lost;
    /////
    public void StartPuzzle()
    {
        m_board_creator.StartBoardInit(board, this);
        m_endViewDialog.Hide();
        m_current_lives = m_max_lives;
        
    }

    public void SwitchMarkMode()
    {
        if (PuzzleBlackboard.IsMarkingMode())
        {
            Debug.Log("set marking mode false");
            img_mode_button_gfx.sprite = img_box_crossed;
            PuzzleBlackboard.SetMarkModeOn(false);
        }
        else
        {
            Debug.Log("set marking mode true");
            img_mode_button_gfx.sprite = img_box_filled;
            PuzzleBlackboard.SetMarkModeOn(true);
        }
    }

    public void FailedClick()
    {
        m_current_lives--;
        img_lives[m_current_lives].sprite = img_life_lost;
        if (m_current_lives <= 0){
             Debug.Log("game over");
            m_endViewDialog.Show(false);
        }
    }

    public bool IsBoardFinished(Tuple<int, int> coords)
    {
        board[coords.Item1, coords.Item2] = false;
        for (int i = 0; i < m_board_row_count; i++)
        {
            for (int j = 0; j < m_board_column_count; j++)
            {
                if (board[i, j] == true)
                {
                    return false;
                }
            }
        }
        Debug.Log("board finished");
        m_endViewDialog.Show(true);
        return true;
    }

}
