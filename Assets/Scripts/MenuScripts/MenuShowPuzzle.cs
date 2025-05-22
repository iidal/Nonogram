using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShowPuzzle : MonoBehaviour
{

    // this script should hold and manage info of available puzzles
    // probable read a json from resources folder
    // after clicking start, show packages of puzzles,
    // after clicking a package, show puzzles


    // Start is called before the first frame update
    void Start()
    {
        TextAsset bindata = Resources.Load("Puzzles/v0/puzzles.json") as TextAsset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePackages()
    {
        // instantiate buttons for each package that is defined in
        // button needs to also hold info for how many puzzles have been completed/ how many stars etc has been collected 
    }
    public void CreatePuzzles()
    {
        // instantiate buttons for each package, need to also hold info if is completed, how many stars, show completed image...
    }
}
