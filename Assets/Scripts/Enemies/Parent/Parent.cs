using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : Entity
{
    public Parent_IdleState idleState { get; private set; }
    public Parent_MoveState moveState { get; private set; }
    public Parent_AggroState aggroState { get; private set; }
    public Parent_MeleeAttackState meleeAttackState { get; private set; }
    public Parent_DeathState deathState { get; private set; }
    public Parent_SpawnState spawnState { get; private set; }


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
        moveState = new Parent_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Parent_IdleState(this, stateMachine, "idle", idleStateData, this);
        aggroState = new Parent_AggroState(this, stateMachine, "move", aggroStateData, this);
        spawnState = new Parent_SpawnState(this, stateMachine, "spawn", spawnStateData, this);
        deathState = new Parent_DeathState(this, stateMachine, "death", deathStateData, this);

        meleeAttackState = new Parent_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);

        stateMachine.Initialize(spawnState);
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deathState);
        AudioManager.instance.PlaySFX(8); //TODO
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        AudioManager.instance.PlaySFX(9);
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
