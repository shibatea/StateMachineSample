using StateMachineSample.Lib.StateMachines.Application.Effect;
using StateMachineSample.Lib.StateMachines.Application.StateMachine;
using StateMachineSample.Lib.StateMachines.Application.Trigger;
using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class CleanState : Common.State
    {
        private CleanState() : base("Clean")
        {
            OnEntry = EntryEventHandler;
            OnDo = DoEventHandler;
        }

        public static CleanState Instance { get; } = new CleanState();

        public CleanStateMachine SubContext { get; private set; }

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap
        {
            {SwitchStopTrigger.Instance.Name, SwitchStopTriggerHandler}
        };


        private void EntryEventHandler(Common.StateMachine context)
        {
            var parent = context.GetAs<ModelStateMachine>();

            SubContext = new CleanStateMachine(parent);
        }

        private void DoEventHandler(Common.StateMachine context)
        {
            SubContext.Update();

            if (SubContext.CurrentState is CleanFinalState)
            {
                var effect = CleanEndEffect.Instance;

                context.ChangeState(RunningState.Instance, effect);
            }
        }

        private void SwitchStopTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            var effect = args.Trigger.Effect;

            context.ChangeState(StopState.Instance, effect);
        }
    }
}