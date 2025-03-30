using UnityEngine;

[CreateAssetMenu(fileName = "Puzzle", menuName = "ScriptableObjects", order = 1)]
public class PuzzleScriptable : ScriptableObject
{
    public string prefabName;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;
}