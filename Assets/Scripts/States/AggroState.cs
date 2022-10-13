using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroState : State
{
    protected D_AggroState stateData;
    protected bool isPlayerInMinAggroRange;
    protected bool isPlayerInMaxAggroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isInAttackRange;
    // protected bool canTeleport;

    protected float moveTime;

    public AggroState(Entity entity, FSM stateMachine, string animBoolName, D_AggroState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Checks()
    {
        base.Checks();
        isPlayerInMinAggroRange = entity.CheckMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckMaxAggroRange();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isInAttackRange = entity.CheckPlayerInAttackRange();
        // canTeleport = false;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.movementSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (entity.playerGO.transform.position.x < entity.transform.position.x)
        { //player is on left
            if (entity.facingDirection == 1)
            {
                entity.Flip();
                entity.SetVelocity(stateData.movementSpeed);
            }
        }
        else
        { //player is on right
            if (entity.facingDirection == -1)
            {
                entity.Flip();
                entity.SetVelocity(stateData.movementSpeed);
            }
        }
    }

    private void SetRandomMoveTime()
    {
        moveTime = Random.Range(stateData.minMoveTime, stateData.maxMoveTime);
    }

}
