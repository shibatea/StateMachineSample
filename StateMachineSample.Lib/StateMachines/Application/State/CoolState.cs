using StateMachineSample.Lib.StateMachines.Application.StateMachine;
using StateMachineSample.Lib.StateMachines.Application.Trigger;
using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class CoolState : Common.State
    {
        private CoolState() : base("Cool")
        {
            OnDo = DoEventHandler;
        }

        public static CoolState Instance { get; } = new CoolState();

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap
        {
            {SwitchHeatTrigger.Instance.Name, SwitchHeatTriggerHandler},
            {SwitchDryTrigger.Instance.Name, SwitchDryTriggerHandler}
        };

        private void DoEventHandler(Common.StateMachine context)
        {
            var stm = context.GetAs<RunningStateMachine>();

            var model = stm.Model;

            model.CoolControl();
        }

        private void SwitchHeatTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            context.ChangeState(HeatState.Instance);
        }

        private void SwitchDryTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            context.ChangeState(DryState.Instance);
        }
    }
}