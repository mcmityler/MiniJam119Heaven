using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenGateScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col);
        if(col.gameObject.tag == "Enemy"){
            col.gameObject.GetComponent<HittingScript>().InAttackRange(this.gameObject);
        }
    }
}
