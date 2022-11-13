using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudArmScript : MonoBehaviour
{
    [SerializeField] GameObject _armGrabPoint;
    [SerializeField] GameObject _grabbedEnemy = null;
    void Update(){
        if(_grabbedEnemy != null){
            _grabbedEnemy.gameObject.transform.position = _armGrabPoint.transform.position;
        }
    }
     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && this.gameObject.tag == "Ally")
        {
            col.gameObject.GetComponent<HittingScript>().InAttackRange(this.gameObject);
            _grabbedEnemy = col.gameObject;
        }
    }
    public void CloudArmHitDone(){
        Debug.Log("Ensure its not a boss, if it is destroy this but not the boss");
        Destroy(_grabbedEnemy);
        Destroy(this.gameObject);
    }
}
