using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuManager : MonoBehaviour
{


    /////
    void Start()
    {
        StaticMenuManager.Init();
    }
    public void OnClickPuzzlePack(GameObject currentMenuView){
        StaticMenuManager.SelectMenu(MenuTabs.PUZZLE_PACK_VIEW, currentMenuView.gameObject);
    }
 
}
