/*
By Tyler McMillan
Description: Script that is attatched to beam of light explosion to play sound at correct time
*/
using UnityEngine;

public class BeamLightScript : MonoBehaviour
{

    public void PlayBeamSound()
    {
        FindObjectOfType<AudioManager>().Play("BeamHitSound");
    }
}
