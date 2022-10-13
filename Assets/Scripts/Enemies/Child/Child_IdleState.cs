using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_IdleState : IdleState
{
    private Child child;
    public Child_IdleState(Entity entity, FSM stateMachine, string animBoolName, D_IdleState stateData, Child child) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.child = child;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAggroRange)
        {
            stateMachine.ChangeState(child.aggroState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(child.moveState);
        }
    }
}
