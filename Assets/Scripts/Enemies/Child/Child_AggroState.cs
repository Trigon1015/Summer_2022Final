using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_AggroState : AggroState
{
    private Child child;

    public Child_AggroState(Entity entity, FSM stateMachine, string animBoolName, D_AggroState stateData, Child child) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.child = child;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(child.idleState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            entity.Flip(true);
            entity.SetVelocity(stateData.movementSpeed);
        }
        else if (isInAttackRange)
        {
            stateMachine.ChangeState(child.meleeAttackState);
        }
    }
}
