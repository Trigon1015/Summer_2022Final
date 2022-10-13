using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGolem : Entity
{

    public bGolem_IdleState idleState { get; private set; }
    public bGolem_MoveState moveState { get; private set; }
    public bGolem_AggroState aggroState { get; private set; }
    public bGolem_MeleeAttackState meleeAttackState { get; private set; }
    public bGolem_DeathState deathState { get; private set; }
    public bGolem_SpawnState spawnState { get; private set; }


    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_AggroState aggroStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    private D_DeathState deathStateData;
    [SerializeField]
    private D_SpawnState spawnStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();
        moveState = new bGolem_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new bGolem_IdleState(this, stateMachine, "idle", idleStateData, this);
        aggroState = new bGolem_AggroState(this, stateMachine, "move", aggroStateData, this);
        spawnState = new bGolem_SpawnState(this, stateMachine, "spawn", spawnStateData, this);
        deathState = new bGolem_DeathState(this, stateMachine, "death", deathStateData, this);

        meleeAttackState = new bGolem_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);

        stateMachine.Initialize(spawnState);
    }

    public override void Die()
    {
        base.Die();
        AudioManager.instance.PlaySFX(19);
        stateMachine.ChangeState(deathState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    // public override void ResetVelocity()
    // {
    //     base.ResetVelocity();
    //     if (previousVelocity == 0f)
    //     {
    //         stateMachine.ChangeState(idleState);
    //     }
    // }

}
