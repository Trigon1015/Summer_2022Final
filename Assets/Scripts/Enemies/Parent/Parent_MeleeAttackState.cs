using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_MeleeAttackState : MeleeAttackState
{
    private Parent parent;

    public Parent_MeleeAttackState(Entity entity, FSM stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Parent parent) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.parent = parent;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(parent.aggroState);
        }
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        AudioManager.instance.PlaySFX(16);
        if (hit)
        {
            GameManager.FindInstance().killedBy = "Parent";
        }
    }
}
