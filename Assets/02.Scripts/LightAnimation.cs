using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnimation : MonoBehaviour
{
    public int LightMode;   // 애니메이션 개수
    public GameObject NeoLight;   // 애니메이션이 들어간 오브젝트

    void Update(){
        if(LightMode == 0){     // 초기값 1 코루틴 시작
            StartCoroutine(AnimateLight());
        }
    }
    IEnumerator AnimateLight(){
        LightMode = Random.Range(1, 4); // 1~3의 값 중 랜덤 실행, 1초씩 정지
        if(LightMode == 1){
            NeoLight.GetComponent<Animator>().Play("NeoLightAnimation1");
            yield return new WaitForSeconds(3f);
        }
        if(LightMode == 2){
            NeoLight.GetComponent<Animator>().Play("NeoLightAnimation2");
            yield return new WaitForSeconds(4f);
        }
        if(LightMode == 3){
            NeoLight.GetComponent<Animator>().Play("NeoLightAnimation3");
            yield return new WaitForSeconds(8f);
        }
        yield return new WaitForSeconds(0.99f); // 1초의 대기시간 만큼 정지
        LightMode = 0;
    }
}
