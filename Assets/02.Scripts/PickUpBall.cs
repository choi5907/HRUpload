using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PickUpBall : MonoBehaviour
{
    public float TheDistance;   // 오브젝트 간의 거리
    public GameObject ActionDisplay;    // 상호작용 키
    public GameObject ActionText;   // 상호작용 메시지
    public GameObject FakeBall;   // 공 오브젝트
    public GameObject GetBall;   // 가진 공 오브젝트
    public GameObject ExtraCross;   // 아이템 크로스
    public GameObject DropBalltrig; // 공 박스 트리거 활성화
    public GameObject TheDoor; // 문 오브젝트
    public GameObject Manne; // 마네킹
    public AudioSource DoorClosed; // 문닫히는 소리
    public AudioSource Slide; // 마네킹 소리

    private void Update() {
        // PlayerRay의 레이캐스트 거리를 저장
        TheDistance = PlayerRay.DistanceFromTarget;
    }

    // 마우스 커서가 올라가 있을 때
    void OnMouseOver() {
        // 거리가 5 이하일 경우 Text 켜기
        if(TheDistance <= 5){
            ActionDisplay.SetActive(true);
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "볼을 줍는다.";
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);
        }else{
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
        }
        // 액션 키가 눌러지고 거리가 5이하면 공 콜라이더와 텍스트끄기
        if(Input.GetButtonDown("Action")){
                FakeBall.SetActive(false);
                GetBall.SetActive(true);
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                DropBalltrig.SetActive(true);
                Manne.GetComponent<Animator>().Play("ManneMov");
                TheDoor.GetComponent<Animator>().Play("DoorClosed");
                StartCoroutine(Waits());
        }
    }
    // 커서가 내려갈 때
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }
    IEnumerator Waits(){
        yield return new WaitForSeconds(0.5f);
        Slide.Play();
        yield return new WaitForSeconds(0.7f);
        DoorClosed.Play();
    }
}
