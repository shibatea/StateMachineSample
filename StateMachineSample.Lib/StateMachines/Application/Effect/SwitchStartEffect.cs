using StateMachineSample.Lib.StateMachines.Application.StateMachine;

namespace StateMachineSample.Lib.StateMachines.Application.Effect
{
    public sealed class SwitchStartEffect : Common.Effect
    {
        public SwitchStartEffect() : base("Switch Start Effect")
        {
        }

        public static SwitchStartEffect Instance { get; } = new SwitchStartEffect();

        protected override void ExecuteAction(Common.StateMachine context)
        {
            var stm = context.GetAs<ModelStateMachine>();

            var model = stm.Model;

            model.Start();
        }
    }
}