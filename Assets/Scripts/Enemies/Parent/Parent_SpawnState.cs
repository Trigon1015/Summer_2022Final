using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_SpawnState : SpawnState
{
    private Parent parent;
    public Parent_SpawnState(Entity entity, FSM stateMachine, string animBoolName, D_SpawnState stateData, Parent parent) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.parent = parent;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(parent.idleState);
        }
    }
}
