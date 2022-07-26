using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 문 클릭 시 Scene 넘기는 스크립트
public class SchoolDoor : MonoBehaviour
{
    // 거리저장변수 상호작용버튼 상호작용텍스트 오브젝트체크
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public AudioSource LockedSound; // 잠긴 소리
    public GameObject Textbox; // 텍스트박스
    public GameObject AllDoor; // 문의 부모오브젝트
    public AudioSource LockedOpen; // 열리는 소리
    public AudioSource Slide; // 스르륵 소리

    private void Update() {
        // PlayerRay의 레이캐스트 거리를 저장
        TheDistance = PlayerRay.DistanceFromTarget;
    }

    // 마우스 커서가 올라가 있을 때
    void OnMouseOver() {
        // 거리가 3 이하일 경우 Text 켜기
        if(TheDistance <= 3){
            // 상호작용텍스트 변경
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "문 열기";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);
        }else{  // 거리 벗어나면 끄기
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
        }
        // 액션 키가 눌러지고 거리가 3이하면 콜라이더와 텍스트끄고 코루틴실행
        if(Input.GetButtonDown("Action")){
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                StartCoroutine(LockedDoor());
        }
    }
    // 커서가 내려갈 때 끄기
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }
    IEnumerator LockedDoor(){
        if(this.gameObject == AllDoor.transform.GetChild(1).gameObject && GlobalInven.ClassKey == true){
            LockedOpen.Play();
            yield return new WaitForSeconds(0.5f);
            this.GetComponent<Animator>().Play("ClassDoorAni");
            Slide.Play();
        }else if(this.gameObject == AllDoor.transform.GetChild(2).gameObject && GlobalInven.InfiKey == true){
            LockedOpen.Play();
            yield return new WaitForSeconds(0.5f);
            this.GetComponent<Animator>().Play("InfirmaryDoorAni");
            Slide.Play();
        }else{
            LockedSound.Play();
            yield return new WaitForSeconds(1f);
            this.GetComponent<BoxCollider>().enabled = true;
            Textbox.GetComponent<TMPro.TextMeshProUGUI>().text = "문이 잠겨있다.";
            yield return new WaitForSeconds(1.5f);
            Textbox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        } 
    }
}