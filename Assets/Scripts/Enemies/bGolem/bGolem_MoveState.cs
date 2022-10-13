using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGolem_MoveState : MoveState
{

    private bGolem golem;

    public bGolem_MoveState(Entity entity, FSM stateMachine, string animBoolName, D_MoveState stateData, bGolem golem) : base(entity, stateMachine, animBoolName, stateData)
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
        else if (isDetectingWall || !isDetectingLedge)
        {
            golem.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(golem.idleState);
        }
        else if (isMoveTimeOver)
        {
            golem.idleState.SetFlipAfterIdle(Random.value > 0.5f); //randomly set flip if movetime is over
            stateMachine.ChangeState(golem.idleState);
        }
    }
}
