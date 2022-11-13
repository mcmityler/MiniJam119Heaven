/*
By Tyler McMillan
Description: Script attatched to background to make sure no enemy is being hit before it is even on the screen by the beam mage
*/
using UnityEngine;

public class EnemiesInScreenScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Enemy"){
            if(col.gameObject.GetComponent<EnemyMovementScript>() != null){
                col.gameObject.GetComponent<EnemyMovementScript>().SetBeamable();
            }
        }
    }
}
