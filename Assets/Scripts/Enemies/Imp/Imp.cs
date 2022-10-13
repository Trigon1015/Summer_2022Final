using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : Entity
{
    public Imp_IdleState idleState { get; private set; }
    public Imp_MoveState moveState { get; private set; }
    public Imp_AggroState aggroState { get; private set; }
    public Imp_MeleeAttackState meleeAttackState { get; private set; }
    public Imp_TeleportState teleportState { get; private set; }
    public Imp_DeathState deathState { get; private set; }
    public Imp_SpawnState spawnState { get; private set; }


    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_AggroState aggroStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    private D_TeleportState teleportStateData;
    [SerializeField]
    private D_DeathState deathStateData;
    [SerializeField]
    private D_SpawnState spawnStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public AudioClip snd_shoot;
    public AudioClip snd_tele;
    public AudioClip snd_hit;
    public AudioClip snd_die;


    public override void Start()
    {
        base.Start();
        moveState = new Imp_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Imp_IdleState(this, stateMachine, "idle", idleStateData, this);
        aggroState = new Imp_AggroState(this, stateMachine, "move", aggroStateData, this);
        spawnState = new Imp_SpawnState(this, stateMachine, "spawn", spawnStateData, this);
        deathState = new Imp_DeathState(this, stateMachine, "death", deathStateData, this);

        meleeAttackState = new Imp_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        teleportState = new Imp_TeleportState(this, stateMachine, "teleport", teleportStateData, this);

        stateMachine.Initialize(spawnState);
    }

    public override void Die()
    {
        base.Die();
        AudioManager.instance.PlaySFX(4);
        stateMachine.ChangeState(deathState);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        //audioSource.clip = snd_hit;
        //audioSource.Play();
        AudioManager.instance.PlaySFX(5);
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
