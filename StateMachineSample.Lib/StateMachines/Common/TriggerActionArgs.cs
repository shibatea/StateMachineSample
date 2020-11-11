namespace StateMachineSample.Lib.StateMachines.Common
{
    public class TriggerActionArgs
    {
        public TriggerActionArgs(StateMachine context, Trigger trigger)
        {
            Context = context;

            Trigger = trigger;
        }

        public StateMachine Context { get; }

        public Trigger Trigger { get; }
    }
}