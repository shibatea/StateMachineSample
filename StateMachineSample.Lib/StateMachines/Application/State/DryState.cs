using StateMachineSample.Lib.StateMachines.Application.StateMachine;
using StateMachineSample.Lib.StateMachines.Application.Trigger;
using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class DryState : Common.State
    {
        private DryState() : base("Dry")
        {
            OnDo = DoEventHandler;
        }

        public static DryState Instance { get; } = new DryState();

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap
        {
            {SwitchCoolTrigger.Instance.Name, SwitchCoolTriggerHandler},
            {SwitchHeatTrigger.Instance.Name, SwitchHeatTriggerHandler}
        };

        private void DoEventHandler(Common.StateMachine context)
        {
            var stm = context.GetAs<RunningStateMachine>();

            var model = stm.Model;

            model.DryControl();
        }

        private void SwitchCoolTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            context.ChangeState(CoolState.Instance);
        }

        private void SwitchHeatTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            context.ChangeState(HeatState.Instance);
        }
    }
}