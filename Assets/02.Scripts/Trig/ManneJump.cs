using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManneJump : MonoBehaviour
{
    
    public GameObject Manne; // 마네킹 오브젝트
    public AudioSource Slide;    // 끄는소리 사운드

    void OnTriggerEnter( ) {    // 다른 콜라이더와 충돌시 박스콜라이더 끄고 마네킹애니메이션, 소리 재생
        GetComponent<BoxCollider>().enabled = false;
        Manne.GetComponent<Animator>().Play("ManneMov3");
        Slide.Play();
    }
}
