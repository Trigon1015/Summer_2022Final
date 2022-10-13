using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_SpawnState : SpawnState
{
    private Crab crab;

    public Crab_SpawnState(Entity entity, FSM stateMachine, string animBoolName, D_SpawnState stateData, Crab crab) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.crab = crab;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(crab.idleState);
        }
    }
}
