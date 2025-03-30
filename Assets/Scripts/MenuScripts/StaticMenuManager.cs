using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticMenuManager
{
    public static GameObject mainMenu, settings, puzzlePacks, puzzleSelection;
    public static void Init()
    {
        GameObject canvas = GameObject.Find("MenuViews");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settings = canvas.transform.Find("SettingsMenu").gameObject;
        puzzlePacks = canvas.transform.Find("PuzzlePacks").gameObject;
        puzzleSelection = canvas.transform.Find("PuzzleSelection").gameObject;
    }
    public static void SelectMenu(MenuTabs nextMenu, GameObject prevMenu)
    {
        prevMenu.SetActive(false);
        switch(nextMenu){
            case MenuTabs.START:
                mainMenu.SetActive(true);
                break;
            case MenuTabs.SETTINGS:
                settings.SetActive(true);
                break;
            case MenuTabs.PUZZLE_PACK_VIEW:
                puzzlePacks.SetActive(true);
                break;
        
        }
    }


}
