using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Utils.FSM;
using UnityEngine;

public abstract class BaseState
{
    protected BaseStateMachine Ctx;
    protected StateFactory Factory;

    public BaseState(BaseStateMachine context, StateFactory factory)
    {
        Ctx = context;
        Factory = factory;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();

    protected void ChangeState(BaseState targetState)
    {
        targetState.Exit();

        targetState.Enter();

        Ctx.CurrentState = targetState;
    }
}