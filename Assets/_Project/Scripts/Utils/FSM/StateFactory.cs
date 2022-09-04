namespace _Project.Scripts.Utils.FSM
{
    public class StateFactory
    {
        #region States

        public MoveState MoveState;
        public IdleState IdleState;

        #endregion

        private readonly BaseStateMachine _ctx;
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