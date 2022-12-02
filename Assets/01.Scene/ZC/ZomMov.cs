using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomMov : MonoBehaviour
{
    // 시작할 때 캐릭터 상태
    public IdleState startingState;

    // 현재의 캐릭터 상태
    [SerializeField] private State currentState;

    private void Awake(){
        currentState = startingState;
    }
    
    private void FixedUpdate()
    {
        HandleStateMachine();
    }

    private void HandleStateMachine(){
        // Run logic, based on which state we are currently in
        // If logic is met to switch to the next state, we change states
        State nextState;
        if(currentState != null){
            // Run logic
            nextState = currentState.Tick();
            if(nextState != null){
                currentState = nextState;
            }
        }
    }
}
