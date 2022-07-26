using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieJumpTrig : MonoBehaviour
{
    public AudioSource Bang;    // 큰소리 사운드
    public GameObject Screen; // 스크린 오브젝트
    public AudioSource JumpMusic;   // 점프 사운드
    public GameObject FakeWall; // 가짜벽
    public GameObject ManneJumpTrig; // 마네킹 점프트리거

    

    void OnTriggerEnter( ) {    // 콜라이더 접촉 시 박스콜라이더 끄고 애니메이션, 소리 재생, 가짜벽 끄기
        GetComponent<BoxCollider>().enabled = false;
        Screen.GetComponent<Animator>().Play("ScreenJump");
        Bang.Play();
        JumpMusic.Play();
        FakeWall.SetActive(false);
        ManneJumpTrig.SetActive(true);
        ZombieStalking.isStalking = true;
    }
}
