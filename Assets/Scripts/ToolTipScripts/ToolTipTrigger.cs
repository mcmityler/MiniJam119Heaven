using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea(15, 20)][SerializeField] string _content = "";
    [SerializeField] string _header = "";


    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTipSystem.Show(_content, _header);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.Hide();

    }
}