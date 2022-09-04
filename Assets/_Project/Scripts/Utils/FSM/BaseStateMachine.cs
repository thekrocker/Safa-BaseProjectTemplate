using _Project.Scripts.Utils.FSM;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    public BaseState CurrentState { get; set; }

    protected StateFactory StateFactory;

    public virtual void Awake()
    {
        StateFactory = new StateFactory(this);

        SetReferences();
    }

    private void Start()
    {
        SetInitialState();
    }

    private void Update()
    {
        CurrentState?.Update();
    }


    private void SetInitialState()
    {
        CurrentState = GetInitialState();
        CurrentState?.Enter();
    }


    public virtual BaseState GetInitialState() => null;
    protected abstract void SetReferences();
}