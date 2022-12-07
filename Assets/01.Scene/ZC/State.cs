using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    // Tick(틱)이란 액터나 컴포넌트에 일정 간격
    // 보통 한 프레임에 한 번 코드 조각 또는 블루프린트 스크립트를 실행시키는 것
    // This is the base class for all future states
    public virtual State Tick(){
        // 상태의 추상클래스 > 파생으로 오버라이드시켜 사용한다.
        // 현재 목표를 따라가는 상태구현 예정
        // LOGIC TO FOLLOW CURRENT TARGET GOES HERE
        Debug.Log("Running State");
        return this;    
    }
}
