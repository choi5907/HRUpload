using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropTheTest : MonoBehaviour
{
    public float TheDistance;   // 오브젝트 간의 거리
    public GameObject ActionDisplay;    // 상호작용 키
    public GameObject ActionText;   // 상호작용 메시지
    public GameObject ExtraCross;   // 아이템 크로스
    public AudioSource TestSound; // 시험지 소리

    private void Update() {
        // PlayerRay의 레이캐스트 거리를 저장
        TheDistance = PlayerRay.DistanceFromTarget;
    }

    // 마우스 커서가 올라가 있을 때
    void OnMouseOver() {
        // 거리가 5 이하일 경우 Text 켜기
        if(TheDistance <= 5){
            ActionDisplay.SetActive(true);
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "시험지를 놓는다";
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);
        }else{
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
        }
        // 액션 키가 눌러지고 거리가 5이하면 Static변수인 TestCount를 하나씩 뺀다.
        if(Input.GetButtonDown("Action")){
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
            if(GlobalTestCount.TestCount > 0){
                TestSound.Play();
                GlobalTestCount.TestCount -= 1;
                GlobalTestCount.CaseTestCount += 1;
            }
            if(GlobalTestCount.CaseTestCount == 1)
                this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    // 커서가 내려갈 때
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }
}
