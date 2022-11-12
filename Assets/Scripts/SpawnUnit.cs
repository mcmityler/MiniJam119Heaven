using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] GameObject _patrolUnit;
    [SerializeField] GameObject _prayerUnit;

    bool _unitSelected = false;
    bool _isPatrol, _isPrayer = false;
    [SerializeField] Image _lastButtonPressed;
    [SerializeField] CursorSpawnScript _cursorUnit;
    Camera _cam;
    void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _unitSelected) //if you click and a unit is selected
        {
            LeftMouseClicked();
        }
    }
    public void SelectUnit(Image m_thisButton)
    {
        _isPatrol = _isPrayer = false; //automatically false unless told otherwise
        if (m_thisButton.gameObject.tag == "PatrolUnitButton") //is a patrol unit if the patrol unit button was pressed
        {
            _isPatrol = true;
        }
        else if (m_thisButton.gameObject.tag == "PrayerUnitButton")
        {
            _isPrayer = true;

        }
        if (_lastButtonPressed == m_thisButton && _unitSelected) //what to do if they press the same button twice and its still selected (hasnt been placed yet)
        {
            _lastButtonPressed.color = Color.white;
            _unitSelected = false;
            ShowCursor();
            return;
        }
        _unitSelected = true;
        if (_unitSelected)
        {

            m_thisButton.color = Color.green;
            if (_lastButtonPressed != null && _lastButtonPressed != m_thisButton)
            {
                _lastButtonPressed.color = Color.white;
            }
            _lastButtonPressed = m_thisButton;
        }
        else
        {
            m_thisButton.color = Color.white;

        }
        ShowCursor();

    }

    void LeftMouseClicked() //spawn whatever unit is selected and then unselect that unit
    {

        RaycastHit2D[] hits = Physics2D.RaycastAll(_cam.ScreenToWorldPoint(Input.mousePosition), new Vector3(0, 0, 1));

        // If it hits something...
        foreach (var _hit in hits)
        {
            if (_hit.collider != null)
            {
                //Debug.Log(_hit.collider);
                if (_hit.collider != null && _hit.collider.tag == "Manager")
                {
                    Debug.Log("hey");

                    _unitSelected = false;
                    if (_isPatrol)
                    {
                        SpawnPatrol();
                    }
                    if (_isPrayer)
                    {
                        SpawnPrayer();
                    }
                }
            }
        }
    }
    public void SpawnPatrol()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Instantiate(_patrolUnit, mousePosition, Quaternion.identity);
        _unitSelected = false;
        _lastButtonPressed.color = Color.white;
        _cursorUnit.HideCursorUnit();

    }
    public void SpawnPrayer()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Instantiate(_prayerUnit, mousePosition, Quaternion.identity);
        _unitSelected = false;
        _lastButtonPressed.color = Color.white;
        _cursorUnit.HideCursorUnit();

    }

    void ShowCursor()
    {
        if (_unitSelected && _isPatrol)
        {
            _cursorUnit.ShowPatrol();
        }
        else if (_unitSelected == false && _isPatrol)
        {
            _cursorUnit.HideCursorUnit();

        }
        else if (_unitSelected && _isPrayer)
        {
            _cursorUnit.ShowPrayerUnit();
        }
        else if (_unitSelected == false && _isPrayer)
        {
            _cursorUnit.HideCursorUnit();

        }
    }
}
