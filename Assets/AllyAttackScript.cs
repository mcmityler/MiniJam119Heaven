using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttackScript : MonoBehaviour
{
    [SerializeField] int _attackDamage = 1;
    GameObject _hittingObject;
    bool _hitting = false;
     void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col);
        if(col.gameObject.tag == "Enemy"){
            col.gameObject.GetComponent<HittingScript>().InAttackRange(this.gameObject);
            _hittingObject = col.gameObject;
            _hitting = true;
        }
    }
    
}
