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


    public void InitBox(bool filled)
    {
        m_filled_box = filled;
    }
    public void BoxClicked()
    {
        if (PuzzleBlackboard.IsMarkingMode())
        {
            Debug.Log("box clicked in marking mode");
            FillBox();
        }
        else
        {
            Debug.Log("box clicked not marking mode");
            CrossBox();
        }
    }
    void FillBox()
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
    void CrossBox()
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
