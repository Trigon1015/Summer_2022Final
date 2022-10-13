using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_MoveState : MoveState
{
    private Imp imp;

    public Imp_MoveState(Entity entity, FSM stateMachine, string animBoolName, D_MoveState stateData, Imp imp) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.imp = imp;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAggroRange)
        {
            stateMachine.ChangeState(imp.aggroState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            imp.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(imp.idleState);
        }
        else if (isMoveTimeOver)
        {
            imp.idleState.SetFlipAfterIdle(Random.value > 0.5f); //randomly set flip if movetime is over
            stateMachine.ChangeState(imp.idleState);
        }
    }
}
