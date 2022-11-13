using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenGateScript : MonoBehaviour
{
    [SerializeField] List<Sprite> _gateSprites;
    int _currentSpriteNum = 0;
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Enemy"){
            col.gameObject.GetComponent<HittingScript>().InAttackRange(this.gameObject);
        }
    }

    public void ChangeSprite(){
        this.GetComponent<SpriteRenderer>().sprite = _gateSprites[++_currentSpriteNum];
    }
}
