using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipScript : MonoBehaviour
{

    public TMP_Text headerField;
    public TMP_Text contentField;

    public LayoutElement layoutElement;
    public int characterWrapLimit;
    private RectTransform rectTransform; //reference to rect transform to change the size of the tool tip bar
    [SerializeField] private float _closeToRight = 1.15f; //how close should it be to cursor on right of the screen
    [SerializeField] private float _closeToLeft = .15f; //how close should it be to cursor on left of the screen

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); //get rect transform on gameobject so you can resize 
    }
    public void SetText(string content = "", string header = "")
    {
        if (string.IsNullOrEmpty(header) && string.IsNullOrEmpty(content))
        {
            contentField.gameObject.SetActive(false);
            headerField.gameObject.SetActive(false);
            Debug.Log("no content set");
        }
        else if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
            contentField.text = content;
        }
        else if (string.IsNullOrEmpty(content))
        {
            contentField.gameObject.SetActive(false);
            headerField.text = header;

        }
        else
        {
            contentField.gameObject.SetActive(true);
            headerField.gameObject.SetActive(true);
            headerField.text = header;
            contentField.text = content;



        }
        int m_headerLength = headerField.text.Length;
        int m_contentLength = contentField.text.Length;

        layoutElement.enabled = (m_headerLength > characterWrapLimit || m_contentLength > characterWrapLimit) ? true : false;

    }

    private void Update()
    {
        UpdateTooltipLocation();
    }
    private void UpdateTooltipLocation()//update location of the text box to follow the mouse pos 
    {
        Vector2 m_position = Input.mousePosition;
        float m_pivotX = (m_position.x / Screen.width);
        float m_pivotY = (m_position.y / Screen.height);

        if (m_pivotX <= 0.5f) //if mouse is on the left side of screen make text box more right of mouse
        {
            m_pivotX -= m_pivotX + _closeToLeft;
        }
        if (m_pivotX > 0.5f)//if mouse is on the right side of screen make text box more left of mouse
        {
            m_pivotX = _closeToRight;
        }

        rectTransform.pivot = new Vector2(m_pivotX, m_pivotY);
        transform.position = m_position; //change tooltip box pos
    }

}