using UnityEngine;

namespace _Project.Scripts.Utils.FSM
{
    public class MoveState : BaseState
    {
        public MoveState(BaseStateMachine context, StateFactory factory) : base(context, factory)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering the moving state...");
        }

        private float _elapsed;
        private float _total = 2f;

        public override void Update()
        {
            if (_elapsed <= _total)
            {
                _elapsed += Time.deltaTime;
            }
            else
            {
                _elapsed = 0f;
                ChangeState(Factory.IdleState);
            }
        }

        public override void Exit()
        {
        }
    }
}