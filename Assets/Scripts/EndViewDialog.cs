using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndViewDialog : MonoBehaviour
{
    [SerializeField] GameObject m_retryButton;
    [SerializeField] GameObject m_toMenuButton;
    [SerializeField] TMP_Text m_titleText;
    void Start()
    {
    }
    public void Show(bool levelCompleted)
    {
        //disable not needed elements, enable needed elements
        Debug.Log("show end dialog");
        if(levelCompleted)
        {
            m_titleText.text = "Great Job! Level finished";
            m_toMenuButton.SetActive(true);
            m_retryButton.SetActive(false);
        }
        else
        {
            m_titleText.text = "Oops, not quite...";
            m_toMenuButton.SetActive(true);
            m_retryButton.SetActive(true);
        }
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        Debug.Log("hide end dialog");
        gameObject.SetActive(false);
    }
}
