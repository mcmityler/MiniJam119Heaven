using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFireScript : MonoBehaviour
{
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
