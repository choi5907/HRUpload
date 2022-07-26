using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpSchoolKey : MonoBehaviour
{
    public float TheDistance;   // 오브젝트 간의 거리
    public GameObject ActionDisplay;    // 상호작용 키
    public GameObject ActionText;   // 상호작용 메시지
    public GameObject ExtraCross;   // 아이템 크로스
    public GameObject FakeClassKey;   // 교실키 오브젝트
    public GameObject FakeInfiKey;   // 보건실키 오브젝트
    public GameObject RealClassKey;   // 교실키 UI
    public GameObject RealInfiKey;   // 보건실키 UI
    public AudioSource KeySound; // 줍는 소리
    public GameObject InvenPanel; // 인벤토리 패널

    private void Update() {
        // PlayerRay의 레이캐스트 거리를 저장
        TheDistance = PlayerRay.DistanceFromTarget;
    }

    // 마우스 커서가 올라가 있을 때
    void OnMouseOver() {
        // 거리가 5 이하일 경우 Text 켜기
        if(TheDistance <= 5){
            ActionDisplay.SetActive(true);
            if(this.gameObject == FakeClassKey){
                ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "교실 키를 줍는다."; 
            }
            if(this.gameObject == FakeInfiKey){
                ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "보건실 키를 줍는다."; 
            }    
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);
        }else{
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
        }
        // 액션 키가 눌러지고 거리가 5이하면 시험지콜라이더와 텍스트끄기
        if(Input.GetButtonDown("Action")){
            if(this.gameObject == FakeClassKey){
                FakeClassKey.SetActive(false);
                RealClassKey.SetActive(true);
                GlobalInven.ClassKey = true;
                KeySound.Play();
            }
            if(this.gameObject == FakeInfiKey){
                FakeInfiKey.SetActive(false);
                RealInfiKey.SetActive(true);
                GlobalInven.InfiKey = true;
                KeySound.Play();
            }
            if(InvenPanel.activeSelf==false)
                InvenPanel.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
        }
    }
    // 커서가 내려갈 때
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }
}
