using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FSM stateMachine;
    protected Entity entity;
    protected float startTime;
    protected string animBoolName; //which animation the state is in

    public State(Entity entity, FSM stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        Checks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        Checks();
    }

    public virtual void Checks()
    {

    }
}
