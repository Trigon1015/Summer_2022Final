using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGolem_IdleState : IdleState
{
    private bGolem golem;

    public bGolem_IdleState(Entity entity, FSM stateMachine, string animBoolName, D_IdleState stateData, bGolem golem) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.golem = golem;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAggroRange)
        {
            stateMachine.ChangeState(golem.aggroState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(golem.moveState);
        }
    }
}
