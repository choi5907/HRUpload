using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PENote_1 : MonoBehaviour
{
    // 거리저장변수 상호작용버튼 상호작용텍스트 오브젝트체크 노트오브젝트
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject NoteObject;
    public AudioSource NoteSound; // 노트 소리

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
        NoteObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        NoteObject.SetActive(false);
        GetComponent<BoxCollider>().enabled = true;
    }
}
