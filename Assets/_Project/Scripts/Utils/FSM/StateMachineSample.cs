namespace _Project.Scripts.Utils.FSM
{
    public class StateMachineSample : BaseStateMachine
    {
        public override BaseState GetInitialState() => StateFactory.MoveState;

        public override void Awake()
        {
            base.Awake();
            
        }

        protected override void SetReferences()
        {
            
        }
    }
}