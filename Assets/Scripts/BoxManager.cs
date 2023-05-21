using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    bool m_filled_box; //is this box filled
    bool m_box_crossed = false;
    public Button m_box_button;
    public Image m_box_gfx;
    public Sprite img_box_filled;
    public Sprite img_box_failed;
    public Sprite img_box_crossed;

    GameObject m_game_manager; // script that handles whats going on during game, (so not a gameobject but the script itself)
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitBox(bool filled)
    {
        m_filled_box = filled;
    }
    public void FillBox()
    {
        m_box_button.enabled = false;
        if (m_filled_box)
        {
            m_box_gfx.sprite = img_box_filled;
        }
        else
        {
            //fail
            m_box_gfx.sprite = img_box_failed;
            // inform m_game_manager that a wrong click has happened
        }
    }
    public void CrossBox()
    {
        if (m_box_crossed)
        {
            m_box_crossed = false;
            m_box_gfx.sprite = null;


        }
        else
        {
            m_box_crossed = true;
            m_box_gfx.sprite = img_box_crossed;
        }
    }
}
