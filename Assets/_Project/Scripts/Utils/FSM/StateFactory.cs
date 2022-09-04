namespace _Project.Scripts.Utils.FSM
{
    public class StateFactory
    {
        private readonly BaseStateMachine _ctx;

        public MoveState MoveState;
        public IdleState IdleState;

        public StateFactory(BaseStateMachine ctx)
        {
            _ctx = ctx;

            SetStates();
        }

        private void SetStates()
        {
            MoveState = new MoveState(_ctx, this);
            IdleState = new IdleState(_ctx, this);
        }
    }
}