using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BoardCreator : MonoBehaviour
{
    //this script will receive a class of info needed for creating the board
    // first it will need the size of the board
    public GameObject m_boardbox;
    public GameObject m_box_parent;
    public GameObject m_column_hint;
    public GameObject m_column_parent;
    public GameObject m_row_hint;
    public GameObject m_row_parent;
    PuzzleSession m_puzzle_session;


    public string[] m_hints_rows = new string[5];
    public string[] m_hints_columns = new string[5];

    public int rows, columns;

    public void StartBoardInit(bool[,] board, PuzzleSession session)
    {
        // only supporting puzzles of same width and height for now
        m_puzzle_session = session;
        PopulateRowsColums(rows, m_row_hint, m_row_parent, m_hints_rows); //rows
        PopulateRowsColums(columns, m_column_hint, m_column_parent, m_hints_columns); //columns
        PopulateBoard(5, 5, board);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PopulateRowsColums(int size, GameObject element, GameObject parent, string[] hints)
    {

        for (int i = 0; i < size; i++)
        {
            GameObject text_obj = Instantiate(element, parent.transform.position, Quaternion.identity, parent.transform);
            text_obj.GetComponent<TextMeshProUGUI>().text = hints[i];
            // add each instantiated box to a list (maybe)
        }
    }


    void PopulateBoard(int width, int height, bool[,] board)
    {
        float cellSize = m_box_parent.GetComponent<RectTransform>().rect.width/width;
        m_box_parent.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        m_box_parent.GetComponent<GridLayoutGroup>().constraintCount = width;
        m_box_parent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellSize, cellSize);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject box = Instantiate(m_boardbox, m_box_parent.transform.position, Quaternion.identity, m_box_parent.transform);
                Tuple<int, int> coords = new Tuple<int, int>(i, j);
                box.GetComponent<BoxManager>().InitBox(board[i,j], coords, m_puzzle_session);
                // add each instantiated box to a list 
                // give needed info. 1) is the box empty or not
            }
        }
    }
}
