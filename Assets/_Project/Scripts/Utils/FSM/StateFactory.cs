namespace _Project.Scripts.Utils.FSM
{
    public class StateFactory
    {
        public StateFactory(BaseStateMachine ctx)
        {
            _ctx = ctx;

            SetStates();
        }

        #region States

        public MoveState MoveState;
        public IdleState IdleState;

        #endregion

        private readonly BaseStateMachine _ctx;


        private void SetStates()
        {
            MoveState = new MoveState(_ctx, this);
            IdleState = new IdleState(_ctx, this);
        }
    }
}