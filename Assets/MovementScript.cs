using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    float _tempSpeed; //holds speed when it stops

    [SerializeField] bool _isPatrol = false;
    [SerializeField] List<GameObject> _patrolPoints;
    int _currentPatrolPoint = 0;
    [SerializeField] Color TrackingColour = Color.blue;
    [SerializeField] Color DefaultColor = Color.yellow;

    // Start is called before the first frame update
    void Start()
    {
        _tempSpeed = _moveSpeed;
        _patrolPoints[_currentPatrolPoint].GetComponent<SpriteRenderer>().color = TrackingColour;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _dir = _patrolPoints[_currentPatrolPoint].transform.localPosition - this.transform.localPosition;
        this.gameObject.transform.localPosition += _dir.normalized * Time.deltaTime * _moveSpeed; //move towards heaven gate to attack (use normalize to find unit vector so its always the same speed)
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
            if (col.gameObject.tag == "PatrolPoint")
            {
                _patrolPoints[_currentPatrolPoint].GetComponent<SpriteRenderer>().color = DefaultColor; //set last point to reg colour
                _currentPatrolPoint++;

                if (_currentPatrolPoint >= _patrolPoints.Count)
                {
                    _currentPatrolPoint = 0;
                }
                _patrolPoints[_currentPatrolPoint].GetComponent<SpriteRenderer>().color = TrackingColour; //set next point to tacking colour
            }
        }

    }
}
