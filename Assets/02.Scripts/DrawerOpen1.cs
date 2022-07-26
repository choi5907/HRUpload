using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 서랍 여닫는 스크립트
public class DrawerOpen1 : MonoBehaviour
{
    // 거리저장변수 상호작용버튼 상호작용텍스트 오브젝트체크
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public AudioSource Slide; // 서랍장 소리
    public GameObject Drawer; // 문
    private bool DoorisOpen; // 여닫이

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
                    case false : ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "서랍 열기";
                    break;
                    case true : ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "서랍 닫기";
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
                Slide.Play();
                this.GetComponent<BoxCollider>().enabled = false;
                switch(DoorisOpen){
                    case false : Drawer.GetComponent<Animator>().Play("Drawer2Open");
                                 DoorisOpen = true;
                    break;
                    case true : Drawer.GetComponent<Animator>().Play("Drawer2Close");
                                DoorisOpen = false;
                    break;
                }
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                StartCoroutine(WaitDrawer());
        }
    }
    // 커서가 내려갈 때 끄기
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }
    IEnumerator WaitDrawer(){
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<BoxCollider>().enabled = true;
    }
}
