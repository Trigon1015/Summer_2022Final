using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_DeathState : DeathState
{
    private Imp imp;

    public Imp_DeathState(Entity entity, FSM stateMachine, string animBoolName, D_DeathState stateData, Imp imp) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.imp = imp;
    }

    public override void Enter()
    {
        base.Enter();
        //entity.audioSource.clip = imp.snd_die;
        //entity.audioSource.Play();
        AudioManager.instance.PlaySFX(4);
    }
}
