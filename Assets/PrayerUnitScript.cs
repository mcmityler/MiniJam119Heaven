using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerUnitScript : MonoBehaviour
{
    GameObject _manager;
    [SerializeField] int _prayerValue = 2;
    // Start is called before the first frame update
    void Start()
    {
       _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrayerDone(){
        _manager.GetComponent<PrayerPointScript>().AddPrayers(_prayerValue);
    }
}
