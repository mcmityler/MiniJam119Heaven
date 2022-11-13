/*
By Tyler McMillan
Description: Script that is attatched to the prayer unit that allows it to collect prayer points when its animation finishes
*/
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
