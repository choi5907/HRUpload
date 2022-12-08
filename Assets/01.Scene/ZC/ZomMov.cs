using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomMov : MonoBehaviour
{
    // 시작할 때 캐릭터 상태
    public IdleState startingState;

    [Header("Current State")]
    // 현재의 캐릭터 상태
    [SerializeField] private State currentState;
    
    [Header("Current Target")]
    public PlayerMovement currentTarget;

    private void Awake(){
        currentState = startingState;           // 현재상태 = 시작상태 초기화
    }
    
    private void FixedUpdate()                  // 상태 변환 기능을 사용하는 함수
    {
        HandleStateMachine();                   
    }

    private void HandleStateMachine(){
        // Run logic, based on which state we are currently in
        // If logic is met to switch to the next state, we change states
        State nextState;                        // 다음 상태 선언
        if(currentState != null){               // 현재상태가 비어있지 않다면
            // Run logic      
            nextState = currentState.Tick(this);    // 다음 상태.Tcik() 함수 실행
            if(nextState != null){              // 그리고 만약 다음 상태도 비어있지 않다면
                currentState = nextState;       // 현재상태 = 다음상태
            }
        }
    }
}
