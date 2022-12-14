using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;

    protected bool flipAfterIdle; //continues facing the same way after idle
    protected bool isIdleTimeOver;
    protected bool isPlayerInMinAggroRange;
    protected float idleTime;

    public IdleState(Entity entity, FSM stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }
    public override void Checks()
    {
        base.Checks();
        isPlayerInMinAggroRange = entity.CheckMinAggroRange();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
        entity.previousStunVelocity = entity.rb.velocity.x;
        entity.previousKnockbackVelocity = entity.rb.velocity.x;
        isIdleTimeOver = false;
        SetRandomIdleTime();
        Checks();
    }

    public override void Exit()
    {
        base.Exit();
        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        // Checks();
    }

    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
