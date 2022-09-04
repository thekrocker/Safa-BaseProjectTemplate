using UnityEngine;

namespace _Project.Scripts.Utils.FSM
{
    public class IdleState : BaseState
    {
        public IdleState(BaseStateMachine context, StateFactory factory) : base(context, factory)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering Idle state..");
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}