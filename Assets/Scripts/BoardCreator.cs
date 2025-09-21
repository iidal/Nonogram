using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Data;
using System.Linq;

public class BoardCreator : MonoBehaviour
{
    //this script will receive a class of info needed for creating the board
    // first it will need the size of the board
    public GameObject m_boardbox;
    public GameObject m_box_parent;
    public GameObject m_column_hint;    // hint prefab for each column
    public GameObject m_column_parent;
    public GameObject m_row_hint; // hint prefab for each row
    public GameObject m_row_parent;
    PuzzleSession m_puzzle_session;


    public string[] m_hints_rows = new string[5];
    public string[] m_hints_columns = new string[5];

    public int rows, columns;

    public void StartBoardInit(PuzzleScriptable puzzleConfig, PuzzleSession session)
    {
        // only supporting puzzles of same width and height for now
        m_puzzle_session = session;
        List<string> rowsHints = CreateRowsHints(puzzleConfig.rows);
        List<string> columnsHints = CreateColumnsHints(puzzleConfig.rows);
        PopulateRowsColums(m_row_hint, m_row_parent, rowsHints); //rows
        PopulateRowsColums(m_column_hint, m_column_parent, columnsHints); //columns

        PopulateBoard(puzzleConfig);
    }

    void PopulateBoard(PuzzleScriptable puzzleConfig)
    {
        float cellSize = m_box_parent.GetComponent<RectTransform>().rect.width / puzzleConfig.rowCount;
        m_box_parent.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        m_box_parent.GetComponent<GridLayoutGroup>().constraintCount = puzzleConfig.rowCount;
        m_box_parent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellSize, cellSize);
        int rowIndex = 0;
        foreach (PuzzleScriptable.Row row in puzzleConfig.rows)
        {
            for (int i = 0; i < row.row.Length; i++)
            {
                GameObject box = Instantiate(m_boardbox, m_box_parent.transform.position, Quaternion.identity, m_box_parent.transform);
                Tuple<int, int> coords = new Tuple<int, int>(rowIndex, i);
                box.GetComponent<BoxManager>().InitBox(row.row[i], coords, m_puzzle_session);
            }
            rowIndex++;
        }
    }

    void PopulateRowsColums(GameObject element, GameObject parent, List<string> hints)
    {
        for (int i = 0; i < hints.Count; i++)
        {
            GameObject text_obj = Instantiate(element, parent.transform.position, Quaternion.identity, parent.transform);
            text_obj.GetComponent<TextMeshProUGUI>().text = hints[i];
            // add each instantiated box to a list (maybe)
        }
    }
    //============================================================================================================
    // Generater hints, this is logic that (if at all possible) could be done in the config tool by giving f.ex.
    //  python code that the tool runs to generate the hints when creating the puzzle config
    List<string> CreateRowsHints(PuzzleScriptable.Row[] rows)
    {
        List<string> hints = new();
        foreach (PuzzleScriptable.Row row in rows)
        {
            string hint = "";
            int consecutiveCells = 0;
            for (int rowIndex = 0; rowIndex < row.row.Length; rowIndex++)
            {
                if (row.row[rowIndex])
                {
                    consecutiveCells++;
                }
                else
                {
                    if (consecutiveCells > 0)
                    {
                        hint += consecutiveCells.ToString() + ",";
                        consecutiveCells = 0;
                    }
                }
            }
            if (consecutiveCells == row.row.Length) //if whole row is filled
            {
                hint += consecutiveCells.ToString() + ",";
            }
            hints.Add(hint.TrimEnd(','));
        }
        return hints;
    }
    List<string> CreateColumnsHints(PuzzleScriptable.Row[] rows)
    {
        int columnCount = rows[0].row.Length;
        int rowCount = rows.Length;
        List<string> hints = new();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            string hint = "";
            int consecutiveCells = 0;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                if (rows[rowIndex].row[columnIndex])
                {
                    consecutiveCells++;
                }
                else
                {
                    if (consecutiveCells > 0 || (consecutiveCells > 0 && rowIndex == rowCount - 1)) //if consecutive cells end || if whole column is filled
                    {
                        hint += consecutiveCells.ToString() + ",";
                        consecutiveCells = 0;
                    }
                }
            }
            if (consecutiveCells == rowCount) //if whole column is filled
            {
                hint += consecutiveCells.ToString() + ",";
            }
            hints.Add(hint.TrimEnd(','));
        }
        return hints;
    }


}
