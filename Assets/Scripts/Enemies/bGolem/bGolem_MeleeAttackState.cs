using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGolem_MeleeAttackState : MeleeAttackState
{
    private bGolem golem;

    public bGolem_MeleeAttackState(Entity entity, FSM stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, bGolem golem) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.golem = golem;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(golem.aggroState);
        }
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        AudioManager.instance.PlaySFX(16);
        if (hit)
        {
            GameManager.FindInstance().killedBy = "Colossus";
        }
    }
}
