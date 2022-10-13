using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_AggroState : AggroState
{
    private Parent parent;
    public Parent_AggroState(Entity entity, FSM stateMachine, string animBoolName, D_AggroState stateData, Parent parent) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.parent = parent;
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
            stateMachine.ChangeState(parent.idleState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            entity.Flip(true);
            entity.SetVelocity(stateData.movementSpeed);
        }
        else if (isInAttackRange)
        {
            //transition to attack
            stateMachine.ChangeState(parent.meleeAttackState);
        }
    }
}
