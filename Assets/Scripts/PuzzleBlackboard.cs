using UnityEngine;
public static class PuzzleBlackboard
{
    private static bool m_setting_mark = true;

    ///////////////////////////////////////////////////////////////////////////////////////////////
    public static void SetMarkModeOn(bool set_mark)
    {
        m_setting_mark = set_mark;
        Debug.Log(m_setting_mark);
    }

    public static bool IsMarkingMode()
    {
        Debug.Log(m_setting_mark);

        return m_setting_mark;
    }
    ////////////////////////////////
}