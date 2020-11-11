using StateMachineSample.Lib.StateMachines.Application.StateMachine;
using StateMachineSample.Lib.StateMachines.Application.Trigger;
using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class InitialState : Common.State
    {
        private InitialState() : base("Initial")
        {
            OnEntry = EntryEventHandler;
        }

        public static InitialState Instance { get; } = new InitialState();

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap
        {
            {InitializedTrigger.Instance.Name, InitializedTriggerHandler}
        };

        private void EntryEventHandler(Common.StateMachine context)
        {
            var stm = context.GetAs<ModelStateMachine>();

            var model = stm.Model;

            model.Initialize();

            stm.SendTrigger(InitializedTrigger.Instance);
        }

        private void InitializedTriggerHandler(TriggerActionArgs args)
        {
            var context = args.Context;

            context.ChangeState(StopState.Instance);
        }
    }
}