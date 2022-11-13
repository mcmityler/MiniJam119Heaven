/*
By Tyler McMillan
Description: Script that deals with the in game currency / prayer points / PP
*/
using TMPro;
using UnityEngine;

public class PrayerPointScript : MonoBehaviour
{
    [SerializeField] int _prayerPointCount = 4;
    [SerializeField] TMP_Text _prayerPointText;
    void Start(){
        _prayerPointText.text = "Prayer Points: " + _prayerPointCount.ToString(); //set intial point in text

    }
    public void AddPrayers(int m_prayerPoints){
        _prayerPointCount += m_prayerPoints;
        _prayerPointText.text = "Prayer Points: " + _prayerPointCount.ToString();
        this.gameObject.GetComponent<SpawnUnit>().CheckCosts();
    }
    public int GetPP(){
        return _prayerPointCount;
    }
    public void ResetPP(){
        _prayerPointCount = 0;
        AddPrayers(4);
    }
}
