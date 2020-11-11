using StateMachineSample.Lib.StateMachines.Application.StateMachine;

namespace StateMachineSample.Lib.StateMachines.Application.Effect
{
    public sealed class SwitchStopEffect : Common.Effect
    {
        public SwitchStopEffect() : base("Switch Stop Effect")
        {
        }

        public static SwitchStopEffect Instance { get; } = new SwitchStopEffect();

        protected override void ExecuteAction(Common.StateMachine context)
        {
            var stm = context.GetAs<ModelStateMachine>();

            var model = stm.Model;

            model.Stop();
        }
    }
}