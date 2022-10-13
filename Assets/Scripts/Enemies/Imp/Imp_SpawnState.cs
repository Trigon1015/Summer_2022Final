using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_SpawnState : SpawnState
{
    private Imp imp;
    public Imp_SpawnState(Entity entity, FSM stateMachine, string animBoolName, D_SpawnState stateData, Imp imp) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.imp = imp;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(imp.idleState);
        }
    }
}
