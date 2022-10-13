using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isMoveTimeOver;
    protected bool isPlayerInMinAggroRange;

    protected float moveTime;

    public MoveState(Entity entity, FSM stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Checks()
    {
        base.Checks();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerInMinAggroRange = entity.CheckMinAggroRange();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.movementSpeed);
        isMoveTimeOver = false;
        SetRandomMoveTime();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + moveTime)
        {
            isMoveTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetRandomMoveTime()
    {
        moveTime = Random.Range(stateData.minMoveTime, stateData.maxMoveTime);
    }
}
