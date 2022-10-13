using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGolem_AggroState : AggroState
{
    private bGolem golem;
    public bGolem_AggroState(Entity entity, FSM stateMachine, string animBoolName, D_AggroState stateData, bGolem golem) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.golem = golem;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(golem.idleState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            entity.Flip(true);
            entity.SetVelocity(stateData.movementSpeed);
        }
        else if (isInAttackRange)
        {
            //transition to attack
            stateMachine.ChangeState(golem.meleeAttackState);
        }
    }
}
