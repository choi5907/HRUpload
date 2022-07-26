using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LibraryDoor : MonoBehaviour
{
    // 도서관문, 텍스트박스, 문열리는소리
    public GameObject LibraryOpen;
    public GameObject Textbox;
    public AudioSource DoorOpenSound;
    public bool OnceLibrary;
    // 교실과 보건실 키를 모두 얻을 경우 문이 열리고 소리와 텍스트 애니메이션 실행
    void Update()
    {
        if(GlobalInven.ClassKey == true && GlobalInven.InfiKey == true && OnceLibrary == false){
            OnceLibrary = true;
            this.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(ShowTextbox());
            this.GetComponent<SchoolDoor>().enabled = false;
        }
    }
    IEnumerator ShowTextbox(){
        yield return new WaitForSeconds(0.4f);
        DoorOpenSound.Play();
        LibraryOpen.GetComponent<Animator>().Play("LibraryOpen");
        yield return new WaitForSeconds(.5f);
        Textbox.GetComponent<TMPro.TextMeshProUGUI>().text = "잠긴 문이 열리는 소리가 났다.";
        yield return new WaitForSeconds(1.5f);
        Textbox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }
}
