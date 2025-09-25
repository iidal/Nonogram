using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Unity.Burst;

public static class SaveSystem
{
    private static string path = Path.Combine(Application.persistentDataPath, "gameState.json");
    private static PackList m_cachedData = null;

    public static void Save(PackList packList)
    {
        string json = JsonUtility.ToJson(packList, true);
        File.WriteAllText(path, json);
        Debug.Log("Saved to " + path);
    }

    public static void Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            m_cachedData = JsonUtility.FromJson<PackList>(json);
        }

        // Return empty if no file
        m_cachedData = new PackList { packs = new List<Pack>() };
    }

    public static void UpdatePack(Puzzle puzzle)
    {
        // temp test
        puzzle.id = "test1_1";
        puzzle.completed = true;
        puzzle.points = 420;
        if (m_cachedData != null)
        {
            if (m_cachedData.packs.Count == 0)
            {
                Debug.Log("No packs found, creating new pack");
                m_cachedData.packs.Add(new Pack { id = "pack1", puzzles = new List<Puzzle> { puzzle } });   // TODO get pack id as input here
                Save(m_cachedData);
            }
            foreach (var pack in m_cachedData.packs) // TODO when getting pack id as input here, find pack by that, not by looping 
            {
                var existingPuzzle = pack.puzzles.Find(p => p.id == puzzle.id);
                if (existingPuzzle != null)
                {
                    // Update the existing puzzle
                    existingPuzzle.completed = puzzle.completed;
                    existingPuzzle.points = puzzle.points;
                    break;
                }
                else
                {
                    // Add the new puzzle
                    pack.puzzles.Add(puzzle);
                    break;
                }
            }
        }
        else
        {
            // no cache, try loading again
            Load();
            if (m_cachedData != null)
            {
                UpdatePack(puzzle);
            }
            else
            {
                Debug.LogError("Failed to load cached data in pack updating, please investigate");
                return;
            }
        }
        Save(m_cachedData);
    }
}