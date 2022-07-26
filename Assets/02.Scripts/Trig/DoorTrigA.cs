using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

// 문 클릭 시 Scene 넘기는 스크립트
public class DoorTrigA : MonoBehaviour
{
    // 거리저장변수 상호작용버튼 상호작용텍스트 오브젝트체크 페이드아웃 로드텍스트
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public AudioSource DoorSound; // 문 소리
    public GameObject fadeOut;
    public GameObject loadText;

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
        // 액션 키가 눌러지고 거리가 3이하면 콜라이더와 텍스트끄고, 소리 실행
        if(Input.GetButtonDown("Action")){
                DoorSound.Play();
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                // 페이드아웃 실행, 코루틴 실행
                fadeOut.SetActive(true);
                StartCoroutine(FadeToExit());
        }
    }
    // 커서가 내려갈 때 끄기
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }
    
    // 코루틴 3f기다렸다가 2번 씬 열기
    IEnumerator FadeToExit(){
        while(AudioListener.volume > 0){
            yield return new WaitForSeconds(0.05f);
            AudioListener.volume -= 0.1f;
        }
        yield return new WaitForSeconds(1.5f);
        loadText.SetActive(true);
        SceneManager.LoadScene(2);
    }
}
