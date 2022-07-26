using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManneJumpTrig : MonoBehaviour
{
    public GameObject ManneCol; // 마네킹 콜라이더
    public AudioSource Violin; // 점프사운드
    private bool oncetrig; // 한번만
    
    void Update() {
        if( this.transform.GetChild(0).gameObject.activeSelf == false && oncetrig == false){
            oncetrig = true;
            StartCoroutine(Manne2Jump());
        }   
    }
    IEnumerator Manne2Jump(){
        yield return new WaitForSeconds(1f);
        ManneCol.GetComponent<Animator>().Play("Manne2Jump");
        yield return new WaitForSeconds(0.2f);
        Violin.Play();
        yield return new WaitForSeconds(3f);
        ManneCol.transform.GetChild(0).gameObject.SetActive(false);
    }
}
