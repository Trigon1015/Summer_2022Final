using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_MoveState : MoveState
{
    private Child child;

    public Child_MoveState(Entity entity, FSM stateMachine, string animBoolName, D_MoveState stateData, Child child) : base(entity, stateMachine, animBoolName, stateData)
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
        else if (isDetectingWall || !isDetectingLedge)
        {
            child.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(child.idleState);
        }
        else if (isMoveTimeOver)
        {
            child.idleState.SetFlipAfterIdle(Random.value > 0.5f); //randomly set flip if movetime is over
            stateMachine.ChangeState(child.idleState);
        }
    }
}
