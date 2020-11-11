using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class CleanFinalState : Common.State
    {
        private CleanFinalState() : base("Clean Final")
        {
        }

        public static CleanFinalState Instance { get; } = new CleanFinalState();

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap();
    }
}