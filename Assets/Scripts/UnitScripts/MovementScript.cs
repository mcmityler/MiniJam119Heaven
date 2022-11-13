using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    float _tempSpeed; //holds speed when it stops

    [SerializeField] bool _isPatrol = false;
    [SerializeField] List<GameObject> _patrolPoints;
    [SerializeField] Sprite _flagUp;
    [SerializeField] Sprite _flagDown;

    int _currentPatrolPoint = 0;
    int _lastControlPoint = 0;
    [SerializeField] Slider _unitHealthBarSlider;

    [SerializeField] Color TrackingColour = Color.blue;
    [SerializeField] Color DefaultColor = Color.yellow;

    // Start is called before the first frame update
    void Start()
    {
        _tempSpeed = _moveSpeed;
        if (_isPatrol)
        {
            _patrolPoints[_currentPatrolPoint].GetComponent<SpriteRenderer>().color = TrackingColour;
            _patrolPoints[_currentPatrolPoint].GetComponent<SpriteRenderer>().sprite = _flagUp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPatrol)
        {
            Vector3 _dir = _patrolPoints[_currentPatrolPoint].transform.localPosition - this.transform.localPosition;
            this.gameObject.transform.localPosition += _dir.normalized * Time.deltaTime * _moveSpeed; //move towards heaven gate to attack (use normalize to find unit vector so its always the same speed)
            if (_dir.x > 0 && _moveSpeed > 0) //moving to the right
            {
                // this.gameObject.GetComponent<SpriteRenderer>().flipX = true;

                transform.right = Vector3.left;
                _unitHealthBarSlider.direction = Slider.Direction.RightToLeft;

            }
            else if (_dir.x < 0 && _moveSpeed > 0) //moving to the left
            {
                //this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                transform.right = Vector3.right;
                _unitHealthBarSlider.direction = Slider.Direction.LeftToRight;


            }
        }
    }
    public void StopMovement() //stop enemy cause its attacking
    {
        _moveSpeed = 0;
    }
    public void ResumeMovement() //resume enemy its done attacking
    {
        _moveSpeed = _tempSpeed;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (_isPatrol) //turn move direction when you reach the patrol point
        {
            if (col.gameObject == _patrolPoints[_currentPatrolPoint])
            {
                if (_currentPatrolPoint == 0 && col.gameObject.name == "PatrolPoint1")
                {
                    _currentPatrolPoint = 1;
                    _lastControlPoint = 0;
                }
                else if (_currentPatrolPoint == 1 && col.gameObject.name == "PatrolPoint2")
                {
                    _currentPatrolPoint = 0;
                    _lastControlPoint = 1;

                }
                _patrolPoints[_lastControlPoint].GetComponent<SpriteRenderer>().color = DefaultColor; //set last point to reg colour
                _patrolPoints[_lastControlPoint].GetComponent<SpriteRenderer>().sprite = _flagDown;
                _patrolPoints[_currentPatrolPoint].GetComponent<SpriteRenderer>().color = TrackingColour; //set next point to tacking colour
                _patrolPoints[_currentPatrolPoint].GetComponent<SpriteRenderer>().sprite = _flagUp;

            }
        }

    }
}
