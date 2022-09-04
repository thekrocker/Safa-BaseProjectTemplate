namespace _Project.Scripts.Utils.FSM
{
    public class StateMachineSample : BaseStateMachine
    {
        public override BaseState GetInitialState()
        {
            return StateFactory.MoveState;
        }

        protected override void SetReferences()
        {
            
        }
    }
}