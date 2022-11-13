/*
By Tyler McMillan
Description: Cloud movement script is on each individual cloud that allows them each to move at random speeds& directions
*/
using UnityEngine;

public class CloudMovementScript : MonoBehaviour
{
    Vector3 _dir = new Vector3(0, 0, 0);
    float _moveSpeed = 2f;
    public void StartMovement()
    {
        do
        {
            _dir = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        }while(_dir.x == 0 && _dir.y == 0);
        _moveSpeed = Random.Range(3f,4f);
    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += _dir * Time.deltaTime * _moveSpeed;
    }
}
