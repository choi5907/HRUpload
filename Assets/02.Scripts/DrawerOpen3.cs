using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 서랍 여닫는 스크립트
public class DrawerOpen3 : MonoBehaviour
{
    // 거리저장변수 상호작용버튼 상호작용텍스트 오브젝트체크
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public AudioSource MetalDoorSound; // 캐비넷소리
    private bool DoorisOpen; // 여닫이
    public GameObject DropTestCol; // 시험지 콜라이더

    private void Update() {
        // PlayerRay의 레이캐스트 거리를 저장
        TheDistance = PlayerRay.DistanceFromTarget;
    }

    // 마우스 커서가 올라가 있을 때
    void OnMouseOver() {
        // 거리가 3 이하일 경우 Text 켜기
        if(TheDistance <= 3){
            // 상호작용텍스트 변경
            switch(DoorisOpen){
                    case false : ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "캐비넷 열기";
                    break;
                    case true : ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "캐비넷 닫기";
                    break;
                }
            
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);
        }else{  // 거리 벗어나면 끄기
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
        }
        // 액션 키가 눌러지고 거리가 3이하면 콜라이더와 텍스트끄고, 소리 실행
        if(Input.GetButtonDown("Action")){
                MetalDoorSound.Play();
                this.GetComponent<BoxCollider>().enabled = false;
                switch(DoorisOpen){
                    case false : this.GetComponent<Animator>().Play("LibraryCaseOpen");
                                 DoorisOpen = true;
                                 DropTestCol.GetComponent<BoxCollider>().enabled = true;
                    break;
                    case true : this.GetComponent<Animator>().Play("LibraryCaseClose");
                                DoorisOpen = false;
                                DropTestCol.GetComponent<BoxCollider>().enabled = false;
                    break;
                }
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                StartCoroutine(WaitCase());
        }
    }
    // 커서가 내려갈 때 끄기
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }
    IEnumerator WaitCase(){
        yield return new WaitForSeconds(0.45f);
        this.GetComponent<BoxCollider>().enabled = true;
    }
}
