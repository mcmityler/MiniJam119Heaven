using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonScript : MonoBehaviour
{
    bool _muted = false;
    [SerializeField] Color _defaultColor = Color.clear;
    [SerializeField] Color _defaultColorOpaque = Color.clear;

    void Start()
    {
        ChangeMuteColor();
    }
    public void ToggleMute()
    {
        _muted = !_muted;
        ChangeMuteColor();
    }
    void ChangeMuteColor()
    {
        if (_muted == false)
        {
            Button b = this.gameObject.GetComponent<Button>();
            ColorBlock cb = b.colors;
            cb.normalColor = _defaultColorOpaque;
            b.colors = cb;
            this.gameObject.GetComponent<Image>().color = _defaultColor;
        }
        else
        {
            Button b = this.gameObject.GetComponent<Button>();
            ColorBlock cb = b.colors;
            cb.normalColor = Color.red;
            b.colors = cb;
            this.gameObject.GetComponent<Image>().color = Color.red;

        }
    }
}
