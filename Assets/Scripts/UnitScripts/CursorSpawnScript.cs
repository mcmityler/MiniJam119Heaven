/*
By Tyler McMillan
Description: Cursor Spawn Script works along side the spawn unit script, this script shows the hologram image of what unit / angel the player has selected on their cursor
*/
using UnityEngine;

public class CursorSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject _spawnImage;
    [SerializeField] Sprite _patrolUnitSprite, _prayerUnitSprite, _beamerUnitSprite,_cloudArmUnitSprite;
    bool _showing = false;
    void Start(){
        HideCursorUnit();
    }
    void Update(){
        if(_showing){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _spawnImage.transform.position = mousePosition;
        }
    }
    public void ShowPatrol(){
        _spawnImage.SetActive(true);
        _spawnImage.GetComponent<SpriteRenderer>().sprite = _patrolUnitSprite;
        _showing = true;
    }
    public void ShowPrayerUnit(){
        _spawnImage.SetActive(true);
        _spawnImage.GetComponent<SpriteRenderer>().sprite = _prayerUnitSprite;
        _showing = true;
    }
     public void ShowBeamerUnit(){
        _spawnImage.SetActive(true);
        _spawnImage.GetComponent<SpriteRenderer>().sprite = _beamerUnitSprite;
        _showing = true;
    }
     public void ShowCloudArmUnit(){
        _spawnImage.SetActive(true);
        _spawnImage.GetComponent<SpriteRenderer>().sprite = _cloudArmUnitSprite;
        _showing = true;
    }

    public void HideCursorUnit(){
        _spawnImage.SetActive(false);
        _showing = false;
    }
}
