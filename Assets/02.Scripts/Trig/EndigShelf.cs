using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndigShelf : MonoBehaviour
{
    private bool OnceTrig; // 한번 실행
    public AudioSource ShelfSound; // 서랍 소리
    public GameObject Textbox; // 텍스트박스
    public GameObject Zombie; // 좀비
    void Update() {
        if(GlobalTestCount.CaseTestCount == 15 && OnceTrig == false){
            OnceTrig = true;
            Zombie.SetActive(false);
            this.GetComponent<Animator>().Play("InfiShelfAni");
            this.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(PickUpKey());
        }    
    }
    IEnumerator PickUpKey(){
        yield return new WaitForSeconds(0.5f);
        ShelfSound.Play();
        Textbox.GetComponent<TMPro.TextMeshProUGUI>().text = "보건실 쪽에서 소리가 났다.";
        yield return new WaitForSeconds(2f);
        Textbox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }
}
