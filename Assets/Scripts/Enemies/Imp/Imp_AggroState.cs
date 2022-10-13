using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_AggroState : AggroState
{
    private Imp imp;
    public float lastTeleportTime;
    private float teleportCooldown = 5f;

    public Imp_AggroState(Entity entity, FSM stateMachine, string animBoolName, D_AggroState stateData, Imp imp) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.imp = imp;
    }

    public override void Enter()
    {
        base.Enter();
        lastTeleportTime = Time.time;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(imp.idleState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            entity.Flip(true);
            entity.SetVelocity(stateData.movementSpeed);
        }
        else if (isInAttackRange)
        {
            //transition to attack
            stateMachine.ChangeState(imp.meleeAttackState);
        }
        else if (Time.time >= lastTeleportTime + teleportCooldown && entity.CheckPlayerIsGrounded())
        {
            stateMachine.ChangeState(imp.teleportState);
            entity.SetVelocity(0f);
        }
    }
}
