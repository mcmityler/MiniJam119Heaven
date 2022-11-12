using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartolPointScript : MonoBehaviour
{
    bool _isMoving = false;
    GameObject _objectToMove;
    void Update()
    {

        if (_isMoving && _objectToMove != null)
        {
            Debug.Log(_objectToMove.name);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _objectToMove.transform.position = mousePosition;
        }
    }
    void OnMouseDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        // If it hits something...
        if (hit.collider != null)
        {
            Debug.Log(hit.collider);
            if (hit.collider.gameObject.tag == "PatrolPoint")
            {
                _isMoving = true;
                _objectToMove = hit.collider.gameObject;
            }
        }
    }
    void OnMouseUp()
    {
        _isMoving = false;
        _objectToMove = null;
    }
}
