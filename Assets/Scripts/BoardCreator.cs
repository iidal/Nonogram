using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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


    public string[] m_hints_rows = new string[5];
    public string[] m_hints_columns = new string[5];

    public int rows, columns;

    // Start is called before the first frame update
    void Start()
    {
        bool[,] board = { { false, false, true, false, false }, { true, true, true, true, true }, { false, false, true, false, false }, { false, false, true, false, false }, { false, false, true, true, false } };

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
            GameObject text_obj = Instantiate(element, new Vector3(0, 0, 0), Quaternion.identity, parent.transform);
            text_obj.GetComponent<TextMeshProUGUI>().text = hints[i];
            // add each instantiated box to a list (maybe)
        }
    }


    void PopulateBoard(int width, int height, bool[,] board)
    {
        //also needs as parameter the true/falses for each box, probably a 2d array is best

        m_box_parent.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        m_box_parent.GetComponent<GridLayoutGroup>().constraintCount = width;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject box = Instantiate(m_boardbox, new Vector3(0, 0, 0), Quaternion.identity, m_box_parent.transform);
                box.GetComponent<BoxManager>().InitBox(board[i,j]);
                // add each instantiated box to a list 
                // give needed info. 1) is the box empty or not
            }
        }
    }
}
