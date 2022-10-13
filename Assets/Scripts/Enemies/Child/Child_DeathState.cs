using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_DeathState : DeathState
{
    private Child child;

    public Child_DeathState(Entity entity, FSM stateMachine, string animBoolName, D_DeathState stateData, Child child) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.child = child;
    }

    public override void Enter()
    {
        base.Enter();
        //entity.audioSource.clip = child.snd_die;
        // entity.audioSource.Play();
        AudioManager.instance.PlaySFX(8);
    }

}
