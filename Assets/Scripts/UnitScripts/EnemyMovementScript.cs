/*
By Tyler McMillan
Description: Script Attatched to basic enemies to make them move towards the heavens gate
*/
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovementScript : MonoBehaviour
{

    private GameObject _heavenGate;
    [SerializeField] float _moveSpeed = 1f;
    float _tempSpeed; //holds speed when it stops
    [SerializeField] Slider _unitHealthBarSlider;
    bool _isBeamable = false;

    // Start is called before the first frame update
    void Start()
    {
        _heavenGate = GameObject.FindGameObjectWithTag("HeavenGate");
        _tempSpeed = _moveSpeed;
    }
    public void SetBeamable(){
        _isBeamable = true;
    }
    public bool GetBeamable(){
        return _isBeamable;
    }

    // Update is called once per frame
    void Update()
    {
        if (_heavenGate != null)
        {
            Vector3 _dir = _heavenGate.transform.position - this.transform.position;
            this.gameObject.transform.position += _dir.normalized * Time.deltaTime * _moveSpeed; //move towards heaven gate to attack (use normalize to find unit vector so its always the same speed)
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
}
