using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnState : State
{
    protected D_SpawnState stateData;
    protected bool isAnimationFinished;

    public SpawnState(Entity entity, FSM stateMachine, string animBoolName, D_SpawnState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Checks()
    {
        base.Checks();
    }

    public override void Enter()
    {
        base.Enter();
        isAnimationFinished = false;
        entity.atsm.spawnState = this;
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

    public virtual void StartSpawn()
    {
    }

    public virtual void FinishSpawn()
    {
        isAnimationFinished = true;
    }
}
