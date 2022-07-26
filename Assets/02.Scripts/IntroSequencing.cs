using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroSequencing : MonoBehaviour
{
    public GameObject Player;
    public GameObject textBox;
    public GameObject dataDisplay;
    public GameObject placeDisplay;
    public AudioSource naVoice01;
    public AudioSource naVoice02;
    public AudioSource naVoice03;
    public AudioSource naVoice04;
    public AudioSource naVoice05;
    public AudioSource barkSound;

    void Start() {
        AudioListener.volume = 1f;
        Player.GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(SequenceBegin());
    }

    IEnumerator SequenceBegin(){
        yield return new WaitForSeconds(0.5f);
        placeDisplay.SetActive(true);
        dataDisplay.SetActive(true);
        yield return new WaitForSeconds(2f);
        placeDisplay.SetActive(false);
        dataDisplay.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "한 순간이었다.";
        // naVoice0.Play();
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        Player.GetComponent<PlayerMovement>().enabled = true; 
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "목줄을 놓쳤을 때 이미 개는 사라졌고";
        // naVoice02.Play();
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(3f);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "뒤쫓게 된 곳은 조용하기만 했다.";
        // naVoice03.Play();
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "항상 눈에 띄던 장소였지만";
        // naVoice04.Play();
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "이상하게도 낯선 느낌이 들었다.";
        // naVoice05.Play();
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(0.5f);
        // thudsound.Play();
    }
}
