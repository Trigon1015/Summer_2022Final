using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_MeleeAttackState : MeleeAttackState
{
    private Imp imp;

    public Imp_MeleeAttackState(Entity entity, FSM stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Imp imp) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.imp = imp;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(imp.aggroState);
        }
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        //entity.audioSource.clip = imp.snd_shoot;
        //entity.audioSource.Play();
        AudioManager.instance.PlaySFX(6);
        if (hit)
        {
            GameManager.FindInstance().killedBy = "Imp";
        }
    }
}
