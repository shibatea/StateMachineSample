using StateMachineSample.Lib.StateMachines.Application.StateMachine;
using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class DeepCleanState : Common.State
    {
        private DeepCleanState() : base("Deep Clean")
        {
            OnDo = DoEventHandler;
        }

        public static DeepCleanState Instance { get; } = new DeepCleanState();

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap();

        private void DoEventHandler(Common.StateMachine context)
        {
            var stm = context.GetAs<CleanStateMachine>();

            var model = stm.Model;

            var result = model.DeepCleanControl();

            if (result) stm.ChangeState(CleanFinalState.Instance);
        }
    }
}