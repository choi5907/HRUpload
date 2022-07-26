using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manne2Trig : MonoBehaviour
{
    public AudioSource Violin; // 바이올린 사운드
    private bool oncetrig; // 한번만
    void OnTriggerEnter(Collider other) {
        if(oncetrig == false){
            oncetrig = true;
            Violin.Play();
        }  
    }
}
