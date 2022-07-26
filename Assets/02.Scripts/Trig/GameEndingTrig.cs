using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameEndingTrig : MonoBehaviour
{
    // 엔딩 후 메인화면으로
    public GameObject Textbox; // 텍스트박스
    public GameObject EndingText; // 엔딩
    void Start()
    {
        StartCoroutine(EndingToMenu());
    }

    IEnumerator EndingToMenu(){
        Textbox.GetComponent<TMPro.TextMeshProUGUI>().text = "건물 밖으로 나오자";
        yield return new WaitForSeconds(2.5f);
        Textbox.GetComponent<TMPro.TextMeshProUGUI>().text = "방금까지의 건물은 온데간데 없고";
        yield return new WaitForSeconds(2.5f);
        Textbox.GetComponent<TMPro.TextMeshProUGUI>().text = "잊어버린 개도 찾지 못한 채";
        yield return new WaitForSeconds(2.5f);
        EndingText.SetActive(true);
        Textbox.GetComponent<TMPro.TextMeshProUGUI>().text = "집으로 돌아갈 수 있게 되었다.";
        yield return new WaitForSeconds(2.5f);
        while(AudioListener.volume > 0){
            yield return new WaitForSeconds(0.05f);
            AudioListener.volume -= 0.1f;
        }
        SceneManager.LoadScene(0);
    }
}
