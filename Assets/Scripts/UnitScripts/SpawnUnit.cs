/*
By Tyler McMillan
Description: Spawn unit script deals with user clicking unit/angel buttons and spawns them where the user clicks. Also checks it is affordable
*/
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] GameObject _patrolUnit;
    [SerializeField] GameObject _prayerUnit;
    [SerializeField] GameObject _beamerUnit;
    [SerializeField] GameObject _cloudArmUnit;

    [SerializeField] int _patrolCost, _prayerCost, _beamerCost, _cloudCost;
    [SerializeField] Image _patrolButton, _prayerButton, _beamerButton, _cloudButton;
    bool _unitSelected = false;
    bool _isPatrol, _isPrayer, _isBeamer, _isCloudArm = false;
    [SerializeField] Image _lastButtonPressed;
    [SerializeField] CursorSpawnScript _cursorUnit;
    Camera _cam;
    void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        CheckCosts();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _unitSelected) //if you click and a unit is selected
        {
            LeftMouseClicked();
        }
    }
    public void CheckCosts()
    {
        int m_pp = this.gameObject.GetComponent<PrayerPointScript>().GetPP();
        if (m_pp < _prayerCost)
        {
            _prayerButton.color = Color.red;
        }
        else if (_prayerButton.color != Color.green)
        {
            _prayerButton.color = Color.white;
        }
        if (m_pp < _patrolCost)
        {
            _patrolButton.color = Color.red;
        }
        else if (_patrolButton.color != Color.green)
        {
            _patrolButton.color = Color.white;
        }
        if (m_pp < _beamerCost)
        {
            _beamerButton.color = Color.red;
        }
        else if (_beamerButton.color != Color.green)
        {
            _beamerButton.color = Color.white;
        }
        if (m_pp < _cloudCost)
        {
            _cloudButton.color = Color.red;
        }
        else if (_cloudButton.color != Color.green)
        {
            _cloudButton.color = Color.white;
        }
    }
    public void SelectUnit(Image m_thisButton)
    {
        _isPatrol = _isPrayer = _isBeamer = _isCloudArm = false; //automatically false unless told otherwise
        if (m_thisButton.color == Color.red) //ignore this script if you cant afford button
        {
            return;
        }
        if (m_thisButton.gameObject.tag == "PatrolUnitButton") //is a patrol unit if the patrol unit button was pressed
        {
            _isPatrol = true;
        }
        else if (m_thisButton.gameObject.tag == "PrayerUnitButton")
        {
            _isPrayer = true;

        }
        else if (m_thisButton.gameObject.tag == "BeamMageUnitButton")
        {
            _isBeamer = true;

        }
        else if (m_thisButton.gameObject.tag == "CloudArmUnitButton")
        {
            _isCloudArm = true;

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
        bool _hitAlly = false;
        bool _hitManager = false;
        // If it hits something...
        foreach (var _hit in hits)
        {
            if (_hit.collider != null)
            {
                //Debug.Log(_hit.collider);
                if (_hit.collider != null && _hit.collider.tag == "Manager")
                {
                    _hitManager = true;
                }
                if (_hit.collider != null && _hit.collider.tag == "Ally")
                {
                    _hitAlly = true;
                }
            }
        }
        if (_hitManager && !_hitAlly)
        {
            _unitSelected = false;
            if (_isPatrol)
            {
                Spawn("Patrol");
                this.gameObject.GetComponent<PrayerPointScript>().AddPrayers(-_patrolCost);
            }
            if (_isPrayer)
            {
                Spawn("Prayer");
                this.gameObject.GetComponent<PrayerPointScript>().AddPrayers(-_prayerCost);

            }
            if (_isBeamer)
            {
                Spawn("Beamer");
                this.gameObject.GetComponent<PrayerPointScript>().AddPrayers(-_beamerCost);

            }
            if (_isCloudArm)
            {
                Spawn("CloudArm");
                this.gameObject.GetComponent<PrayerPointScript>().AddPrayers(-_cloudCost);

            }
        }
    }
    public void Spawn(string _unitName)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        switch (_unitName)
        {
            case "Patrol":

                Instantiate(_patrolUnit, mousePosition, Quaternion.identity);
                break;
            case "Prayer":

                Instantiate(_prayerUnit, mousePosition, Quaternion.identity);
                break;
            case "Beamer":
                Instantiate(_beamerUnit, mousePosition, Quaternion.identity);

                break;
            case "CloudArm":
                Instantiate(_cloudArmUnit, mousePosition, Quaternion.identity);

                break;
        }

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
        else if (_unitSelected && _isPrayer)
        {
            _cursorUnit.ShowPrayerUnit();
        }
        else if (_unitSelected && _isBeamer)
        {
            _cursorUnit.ShowBeamerUnit();
        }
        else if (_unitSelected && _isCloudArm)
        {
            _cursorUnit.ShowCloudArmUnit();
        }
        else if ((_unitSelected == false && _isPrayer) || (_unitSelected == false && _isBeamer) || (_unitSelected == false && _isPatrol) || (_unitSelected == false && _isCloudArm))
        {
            _cursorUnit.HideCursorUnit();

        }
    }
}

