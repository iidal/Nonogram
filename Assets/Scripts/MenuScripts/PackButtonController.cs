using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PackButtonController : MonoBehaviour
{
    MenuManager m_menuManager;
    int m_packId;
    public void init_button(MenuManager manager, int id)
    {
        m_menuManager = manager;
        m_packId = id;
    }
    public void OnButtonClick()
    {
        m_menuManager.OnClickPuzzlePack(m_packId);
    }
}
