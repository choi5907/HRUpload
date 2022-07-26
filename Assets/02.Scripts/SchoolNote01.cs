using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SchoolNote01 : MonoBehaviour
{
    // 거리저장변수 상호작용버튼 상호작용텍스트 오브젝트체크 노트오브젝트
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject NoteBack;
    public AudioSource NoteSound; // 노트 소리
    public GameObject NoteText; // 노트 텍스트
    public GameObject NoteText1; // 노트 텍스트

    private void Update() {
        // PlayerRay의 레이캐스트 거리를 저장
        TheDistance = PlayerRay.DistanceFromTarget;
    }

    // 마우스 커서가 올라가 있을 때
    void OnMouseOver() {
        // 거리가 3 이하일 경우 Text 켜기
        if(TheDistance <= 3){
            // 상호작용텍스트 변경
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "메모 읽기";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);
        }else{  // 거리 벗어나면 끄기
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
        }
        // 액션 키가 눌러지고 거리가 3이하면 콜라이더와 텍스트끄고, 노트오브젝트 실행
        if(Input.GetButtonDown("Action")){
                GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                NoteSound.Play();
                StartCoroutine(WaitForRead());
        }
    }
    // 커서가 내려갈 때 끄기
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }
    IEnumerator WaitForRead(){
        NoteText.GetComponent<TMPro.TextMeshProUGUI>().text = "퇴근 전 유의사항\n\n1.시험종이는 모두\n도서관캐비넷에 넣을것\n2.교실열쇠는 책상위에\n3.모든 일을 마치면\n보건실 찬장을 확인";
        NoteText1.GetComponent<TMPro.TextMeshProUGUI>().text = "- 행정실 -";
        NoteBack.SetActive(true);
        yield return new WaitForSeconds(4f);
        NoteBack.SetActive(false);
        GetComponent<BoxCollider>().enabled = true;
    }
}
