using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGolem_DeathState : DeathState
{
    private bGolem golem;

    public bGolem_DeathState(Entity entity, FSM stateMachine, string animBoolName, D_DeathState stateData, bGolem golem) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.golem = golem;
    }

    public override void Enter()
    {
        base.Enter();
        GameManager.FindInstance().bossKill++;
    }
}
