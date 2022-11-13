using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamLightScript : MonoBehaviour
{

    public void PlayBeamSound()
    {
        FindObjectOfType<AudioManager>().Play("BeamHitSound");
    }
}
