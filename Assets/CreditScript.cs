using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour
{
    public void OpenGoogleCredits(){
        Application.OpenURL("https://docs.google.com/document/d/1784MwqQ1D8fKZ1ULxrWFdjEV359jMdwmKwiu55YQmg8/edit?usp=sharing");
    }
    public void OpenFinnMusic(){
        Application.OpenURL("https://soundcloud.com/finntalisker");
    }
    public void OpenCreditScreen(){
        this.gameObject.GetComponent<Animator>().SetTrigger("Open");
    }
    public void CloseCreditScreen(){
        this.gameObject.GetComponent<Animator>().SetTrigger("Close");
    }
}
