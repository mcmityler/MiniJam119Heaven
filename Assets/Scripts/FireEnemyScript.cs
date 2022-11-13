/*
By Tyler McMillan
Description: Script for fire enemy unit that instantly kills and allies that walk through it
*/
using UnityEngine;

public class FireEnemyScript : MonoBehaviour
{
    [SerializeField] float _fireLifeLength = 2f;

    void Start()
    {
        Destroy(this.gameObject, _fireLifeLength);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ally")
        {

            if (col.gameObject.GetComponent<MovementScript>() != null)
            {
                if (col.gameObject.GetComponent<MovementScript>().GetIsPatrol())
                {
                    Destroy(col.gameObject.transform.parent.gameObject);
                    return;
                }
            }
            Destroy(col.gameObject);
        }
    }
}
