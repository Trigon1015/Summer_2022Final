using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_MeleeAttackState : MeleeAttackState
{
    private Crab crab;

    public Crab_MeleeAttackState(Entity entity, FSM stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Crab crab) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.crab = crab;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(crab.aggroState);
        }
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        AudioManager.instance.PlaySFX(14);
        if (hit)
        {
            GameManager.FindInstance().killedBy = "Sand Crab";
        }
    }
}
