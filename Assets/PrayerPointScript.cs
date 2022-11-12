using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrayerPointScript : MonoBehaviour
{
    int _prayerPointCount = 0;
    [SerializeField] TMP_Text _prayerPointText;
    void Start(){
        _prayerPointText.text = "Prayer Points: " + _prayerPointCount.ToString(); //set intial point in text

    }
    public void AddPrayers(int m_prayerPoints){
        _prayerPointCount += m_prayerPoints;
        _prayerPointText.text = "Prayer Points: " + _prayerPointCount.ToString();
    }
}
