using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parent_DeathState : DeathState
{
    private Parent parent;

    public Parent_DeathState(Entity entity, FSM stateMachine, string animBoolName, D_DeathState stateData, Parent parent) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.parent = parent;
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.instance.PlaySFX(4); //TODO
    }
}
