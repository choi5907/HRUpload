using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueTargetState : State
{
    public override State Tick(ZomMov zomMov)                    
    {
        // 추격함수의 틱 오버라이드
        Debug.Log("RUNNING pursue target state");
        return this;
    }
}
