/*
By Tyler McMillan
Description: Cloud Script deals with the start screen and the clouds that are on it
*/
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    // Start is called before the first frame update
[SerializeField] Animator _unitButtonAnimator;
[SerializeField] Animator _startScreenAnimator;
[SerializeField] GameObject _manager;

    void Start()
    {
        RandomizeIdleSpeed();
    }
    void RandomizeIdleSpeed(){
        foreach (var _cloudAnimator in this.gameObject.GetComponentsInChildren<Animator>())
        {
            _cloudAnimator.SetFloat("idleSpeed", Random.Range(0.005f,0.06f));
        }
    }
    public void StartGame(){
        foreach (var _cloud in this.gameObject.GetComponentsInChildren<CloudMovementScript>())
        {
            _cloud.StartMovement();
        }
        _unitButtonAnimator.SetTrigger("StartGame");
        _startScreenAnimator.SetTrigger("StartGame");
        _manager.GetComponent<EnemyWaveScript>().StartWaves();
        Destroy(transform.parent.gameObject,5f);
    }
}
