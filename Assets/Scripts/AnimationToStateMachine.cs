using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public AttackState attackState;
    public TeleportState teleportState;
    public SpawnState spawnState;
    public DeathState deathState;

    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }

    private void TriggerTeleport()
    {
        teleportState.TriggerTeleport();
    }

    private void FinishTeleport()
    {
        teleportState.FinishTeleport();
    }

    // private void StartSpawn()
    // {
    //     spawnState.StartSpawn();
    // }

    private void FinishSpawn()
    {
        spawnState.FinishSpawn();
    }

    private void TriggerDeath()
    {
        deathState.TriggerDeath();
    }

    private void FinishDeath()
    {
        deathState.FinishDeath();
    }

}
