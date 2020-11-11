using StateMachineSample.Lib.StateMachines.Application.StateMachine;
using StateMachineSample.Lib.StateMachines.Application.Trigger;
using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class RunningState : Common.State
    {
        private RunningState() : base("Running")
        {
            OnEntry = EntryEventHandler;
            OnDo = DoEventHandler;
        }

        public static RunningState Instance { get; } = new RunningState();

        public RunningStateMachine SubContext { get; private set; }

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap
        {
            {SwitchStopTrigger.Instance.Name, SwitchStopTriggerHandler},
            {SwitchCleanTrigger.Instance.Name, SwitchCleanTriggerHandler},
            {SwitchCoolTrigger.Instance.Name, SubContextTriggerHandler},
            {SwitchHeatTrigger.Instance.Name, SubContextTriggerHandler},
            {SwitchDryTrigger.Instance.Name, SubContextTriggerHandler}
        };

        private void EntryEventHandler(Common.StateMachine context)
        {
            if (SubContext == null)
            {
                var parent = context.GetAs<ModelStateMachine>();

                SubContext = new RunningStateMachine(parent);
            }
        }

        private void DoEventHandler(Common.StateMachine context)
        {
            SubContext.Update();
        }

        private void SwitchStopTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            var effect = args.Trigger.Effect;

            context.ChangeState(StopState.Instance, effect);
        }

        private void SwitchCleanTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            context.ChangeState(CleanState.Instance);
        }

        private void SubContextTriggerHandler(TriggerActionArgs args)
        {
            var trigger = args.Trigger;

            var context = SubContext;

            context.SendTrigger(trigger);
        }
    }
}