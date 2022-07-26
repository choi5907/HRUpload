using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieJump2 : MonoBehaviour
{
    public AudioSource Bang;    // 큰소리 사운드
    public GameObject Curtains; // 스크린 오브젝트
    public AudioSource JumpMusic;   // 점프 사운드
    public GameObject Test; // 시험지 오브젝트
    private bool onceTrig; // 한번만실행
    
    void Update() {
        if(Test.transform.GetChild(0).gameObject.activeSelf == false && onceTrig == false){
            onceTrig = true;
            this.GetComponent<BoxCollider>().enabled = true;
        }    
    }
    void OnTriggerEnter(Collider other) {
        GetComponent<BoxCollider>().enabled = false;
        Curtains.GetComponent<Animator>().Play("CurtainsAni");
        Bang.Play();
        JumpMusic.Play();
        StartCoroutine(WaitCurtains());
    }
    IEnumerator WaitCurtains(){
        yield return new WaitForSeconds(0.3f);
        ZombieStalking.isStalking = true; 
    }
}
