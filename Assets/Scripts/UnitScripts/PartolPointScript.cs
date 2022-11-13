/*
By Tyler McMillan
Description: Script that is for the patrol units flags that allows you to move them on the screen
*/
using UnityEngine;

public class PartolPointScript : MonoBehaviour
{
    bool _isMoving = false;
    GameObject _objectToMove;
    Camera _cam;

    void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {

        if (_isMoving && _objectToMove != null)
        {
            //Debug.Log(_objectToMove.name);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _objectToMove.transform.position = mousePosition;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(_cam.ScreenToWorldPoint(Input.mousePosition), new Vector3(0, 0, 1));
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, _layersToIgnore);

            // If it hits something...
            foreach (var _hit in hits)
            {
                if (_hit.collider != null)
                {
                    //Debug.Log(_hit.collider);
                    if (_hit.collider.gameObject.tag == "PatrolPoint")
                    {
                        _isMoving = true;
                        _objectToMove = _hit.collider.gameObject;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {

            _isMoving = false;
            _objectToMove = null;
        }
    }
}
