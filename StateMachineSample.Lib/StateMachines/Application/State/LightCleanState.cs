using StateMachineSample.Lib.StateMachines.Application.StateMachine;
using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class LightCleanState : Common.State
    {
        private LightCleanState() : base("Light Clean")
        {
            OnDo = DoEventHandler;
        }

        public static LightCleanState Instance { get; } = new LightCleanState();

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap();

        private void DoEventHandler(Common.StateMachine context)
        {
            var stm = context.GetAs<CleanStateMachine>();

            var model = stm.Model;

            var result = model.LightCleanControl();

            if (result) stm.ChangeState(CleanFinalState.Instance);
        }
    }
}