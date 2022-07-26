using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTrig : MonoBehaviour
{
    public GameObject InfiShelf; // 서랍
    public AudioSource ShelfSound; // 서랍 사운드
    

    void OnTriggerEnter( ) {
        GetComponent<BoxCollider>().enabled = false;
        InfiShelf.GetComponent<Animator>().Play("InfiShelfAni");
        ShelfSound.Play();
    }
}
