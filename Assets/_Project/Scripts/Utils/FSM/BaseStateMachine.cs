using _Project.Scripts.Utils.FSM;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    public BaseState CurrentState { get; set; }

    protected StateFactory StateFactory;

    public virtual void Awake()
    {
        StateFactory = new StateFactory(this);
    }

    private void Start()
    {
        CurrentState = GetInitialState();
        CurrentState.Enter();
    }

    private void Update()
    {
        CurrentState.Update();
    }

    public virtual BaseState GetInitialState()
    {
        return null;
    }
}