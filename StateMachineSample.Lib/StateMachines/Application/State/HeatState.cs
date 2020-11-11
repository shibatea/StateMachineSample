using StateMachineSample.Lib.StateMachines.Application.StateMachine;
using StateMachineSample.Lib.StateMachines.Application.Trigger;
using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class HeatState : Common.State
    {
        private HeatState() : base("Heat")
        {
            OnDo = DoEventHandler;
        }

        public static HeatState Instance { get; } = new HeatState();

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap
        {
            {SwitchCoolTrigger.Instance.Name, SwitchCoolTriggerHandler},
            {SwitchDryTrigger.Instance.Name, SwitchDryTriggerHandler}
        };

        private void DoEventHandler(Common.StateMachine context)
        {
            var stm = context.GetAs<RunningStateMachine>();

            var model = stm.Model;

            model.HeatControl();
        }

        private void SwitchCoolTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            context.ChangeState(CoolState.Instance);
        }

        private void SwitchDryTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            context.ChangeState(DryState.Instance);
        }
    }
}