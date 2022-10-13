using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_SpawnState : SpawnState
{
    private Child child;
    public Child_SpawnState(Entity entity, FSM stateMachine, string animBoolName, D_SpawnState stateData, Child child) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.child = child;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(child.idleState);
        }
    }
}
