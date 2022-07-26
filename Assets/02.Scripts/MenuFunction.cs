using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuFunction : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadText;
    public AudioSource buttonClick;

    public GameObject loadButton;
    public int loadInt;

    // 세이브 포인트가 있으면 불러오기 활성화
    void Start() {
        loadInt = 0;
        // loadInt = PlayerPrefs.GetInt("AutoSave");
        if(loadInt > 0){
            loadButton.SetActive(true);
        }
        AudioListener.volume = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // 새 게임
    public void NewGameButton(){
        StartCoroutine(NewGameStart());
    }

    // 페이드아웃, 버튼소리 활성화 3초 > load텍스트 활성화 > 2씬  열기
    IEnumerator NewGameStart(){
        buttonClick.Play();
        while(AudioListener.volume > 0){
            yield return new WaitForSeconds(0.05f);
            AudioListener.volume -= 0.1f;
        }
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        loadText.SetActive(true);
        SceneManager.LoadScene(1);
    }

    // 불러오기
    public void LoadGameButton(){
        StartCoroutine(LoadGameStart());
    }
    
    // 페이드아웃, 버튼소리 활성화 3초 > load텍스트 활성화 > 세이브포인트 씬 열기
    IEnumerator LoadGameStart(){
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(2);
        loadText.SetActive(true);
        SceneManager.LoadScene(loadInt);
    }

    // 종료버튼
    public void QuitGameButton(){
        StartCoroutine(QuitGameStart());
    }
    // 페이드아웃, 버튼소리 활성화 3초
    IEnumerator QuitGameStart(){
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(2);
        // 유니티 에디터일 경우 플레이 중지, 애플리케이션은 종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
