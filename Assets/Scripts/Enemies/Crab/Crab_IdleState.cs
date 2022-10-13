using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_IdleState : IdleState
{
    private Crab crab;

    public Crab_IdleState(Entity entity, FSM stateMachine, string animBoolName, D_IdleState stateData, Crab crab) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.crab = crab;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAggroRange)
        {
            stateMachine.ChangeState(crab.aggroState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(crab.moveState);
        }
    }
}
