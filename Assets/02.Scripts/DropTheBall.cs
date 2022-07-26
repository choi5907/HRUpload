using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropTheBall : MonoBehaviour
{
    public float TheDistance;   // 오브젝트 간의 거리
    public GameObject ActionDisplay;    // 상호작용 키
    public GameObject ActionText;   // 상호작용 메시지
    public GameObject GetBall;   // 공 오브젝트
    public GameObject DropBall;   // 가진 공 오브젝트
    public GameObject ExtraCross;   // 아이템 크로스
    public GameObject ZombieJump; // 좀비트리거 활성화
    public GameObject TextBox;  // 텍스트 박스
    public GameObject Manne; // 마네킹
    public AudioSource Slide; // 스르륵 소리
    public AudioSource DoorOpen; // 열리는 소리

    private void Update() {
        // PlayerCasting의 레이캐스트 거리를 저장
        TheDistance = PlayerRay.DistanceFromTarget;
    }

    // 마우스 커서가 올라가 있을 때
    void OnMouseOver() {
        // 거리가 5 이하일 경우 Text 켜기
        if(TheDistance <= 5){
            ActionDisplay.SetActive(true);
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "볼을 박스에 넣는다.";
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);
        }else{
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
        }
        // 액션 키가 눌러지고 거리가 5이하면서 가진공이 활성화돼있으면 가진공 비활성화 진짜공,좀비점프트리거 활성화 
        if(Input.GetButtonDown("Action") && GetBall.activeSelf == true){
                GetBall.SetActive(false);
                DropBall.SetActive(true);
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                ZombieJump.SetActive(true);
                DoorOpen.Play();
                Manne.GetComponent<Animator>().Play("ManneMov2");
                StartCoroutine(OpenDoor());
        }
    }
    // 커서가 내려갈 때
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }
    IEnumerator OpenDoor(){
        TextBox.GetComponent<TMPro.TextMeshProUGUI>().text = "잠긴 문이 열린소리가 들렸다.";
        yield return new WaitForSeconds(0.5f);
        Slide.Play();
        yield return new WaitForSeconds(2f);
        TextBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }
}
