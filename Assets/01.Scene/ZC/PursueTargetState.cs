using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueTargetState : State
{
    public override State Tick()
    {
        Debug.Log("RUNNING pursue target state");
        return this;
    }
}
