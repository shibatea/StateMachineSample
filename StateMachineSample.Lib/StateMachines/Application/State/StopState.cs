using StateMachineSample.Lib.StateMachines.Application.Trigger;
using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class StopState : Common.State
    {
        private StopState() : base("Stop")
        {
        }

        public static StopState Instance { get; } = new StopState();

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap
        {
            {SwitchStartTrigger.Instance.Name, SwitchStartTriggerHandler}
        };


        private void SwitchStartTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            context.ChangeState(RunningState.Instance);
        }
    }
}