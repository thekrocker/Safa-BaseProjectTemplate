using _Project.Scripts.Utils.FSM;

public abstract class BaseState
{
    public BaseState(BaseStateMachine context, StateFactory factory)
    {
        Ctx = context;
        Factory = factory;
    }

    protected readonly BaseStateMachine Ctx;
    protected readonly StateFactory Factory;

    protected void ChangeState(BaseState targetState)
    {
        targetState.Exit();

        targetState.Enter();

        Ctx.CurrentState = targetState;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}