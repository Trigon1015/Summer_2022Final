using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_IdleState : IdleState
{
    private Parent parent;

    public Parent_IdleState(Entity entity, FSM stateMachine, string animBoolName, D_IdleState stateData, Parent parent) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.parent = parent;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAggroRange)
        {
            stateMachine.ChangeState(parent.aggroState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(parent.moveState);
        }
    }
}
