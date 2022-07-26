using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATrig : MonoBehaviour
{
    // 플레이어콜라이더 힌지 팬스움직이는소리 한번만작동
    public GameObject pCol;
    public GameObject Hinge;
    public AudioSource FenceSound;
    private bool once = false;

    // 플레이어콜라이더와 접촉 시 한 번만 실행, 문움직이고 소리
    void OnTriggerEnter(Collider other) {
        if(other.gameObject == pCol && once == false){
            Hinge.GetComponent<Animator>().Play("FenceAni");
            FenceSound.Play();
            once = true;
        }
    }
}
