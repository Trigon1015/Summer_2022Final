using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    // protected D_AttackState stateData;
    protected Transform attackPosition;
    protected bool isAnimationFinished;

    public AttackState(Entity entity, FSM stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void Checks()
    {
        base.Checks();
    }

    public override void Enter()
    {
        base.Enter();
        isAnimationFinished = false;
        entity.atsm.attackState = this;
        entity.SetVelocity(0f);
        entity.previousStunVelocity = entity.rb.velocity.x;
        entity.previousKnockbackVelocity = entity.rb.velocity.x;
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
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
