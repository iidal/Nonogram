using UnityEngine;

[CreateAssetMenu(fileName = "Puzzle", menuName = "ScriptableObjects", order = 1)]
public class PuzzleScriptable : ScriptableObject
{
    public string puzzleName;
    public string puzzleId;
    public string puzzlePackageId;
    public int difficulty; // 1-5

    [System.Serializable]
    public class Row
    {
        public bool[] row;
    }
    public Row[] rows;
    public int rowCount;
    public int columnCount;

}