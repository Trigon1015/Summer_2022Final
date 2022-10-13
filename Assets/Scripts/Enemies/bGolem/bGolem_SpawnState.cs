using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGolem_SpawnState : SpawnState
{
    private bGolem golem;
    public bGolem_SpawnState(Entity entity, FSM stateMachine, string animBoolName, D_SpawnState stateData, bGolem golem) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.golem = golem;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(golem.idleState);
        }
    }
}
