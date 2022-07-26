using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverTrig : MonoBehaviour
{
    // 게임종료 2.5초뒤 메뉴화면으로
    void Start()
    {
        StartCoroutine(GotoMenu());
    }

    IEnumerator GotoMenu(){
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);
    }
}
