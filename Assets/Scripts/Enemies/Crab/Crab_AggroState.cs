using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_AggroState : AggroState
{
    private Crab crab;

    public Crab_AggroState(Entity entity, FSM stateMachine, string animBoolName, D_AggroState stateData, Crab crab) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.crab = crab;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(crab.idleState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            entity.Flip(true);
            entity.SetVelocity(stateData.movementSpeed);
        }
        else if (isInAttackRange)
        {
            stateMachine.ChangeState(crab.meleeAttackState);
        }
    }
}
