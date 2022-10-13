using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_MoveState : MoveState
{
    private Parent parent;

    public Parent_MoveState(Entity entity, FSM stateMachine, string animBoolName, D_MoveState stateData, Parent parent) : base(entity, stateMachine, animBoolName, stateData)
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
        else if (isDetectingWall || !isDetectingLedge)
        {
            parent.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(parent.idleState);
        }
        else if (isMoveTimeOver)
        {
            parent.idleState.SetFlipAfterIdle(Random.value > 0.5f); //randomly set flip if movetime is over
            stateMachine.ChangeState(parent.idleState);
        }
    }
}