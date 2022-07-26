using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardJumpTrig1 : MonoBehaviour
{
    public GameObject Board; // 보드 오브젝트
    public AudioSource DropBoard; // 보드 사운드
    

    void OnTriggerEnter( ) {
        GetComponent<BoxCollider>().enabled = false;
        DropBoard.Play();
        StartCoroutine(WaitSound());
    }
    IEnumerator WaitSound(){
        yield return new WaitForSeconds(0.15f);
        Board.GetComponent<Animator>().Play("BoardJump");
    }
}
