using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_DeathState : DeathState
{
    private Crab crab;

    public Crab_DeathState(Entity entity, FSM stateMachine, string animBoolName, D_DeathState stateData, Crab crab) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.crab = crab;
    }
}
