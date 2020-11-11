using StateMachineSample.Lib.StateMachines.Application.StateMachine;

namespace StateMachineSample.Lib.StateMachines.Application.Effect
{
    public sealed class CleanEndEffect : Common.Effect
    {
        public CleanEndEffect() : base("Clean End Effect")
        {
        }

        public static CleanEndEffect Instance { get; } = new CleanEndEffect();

        protected override void ExecuteAction(Common.StateMachine context)
        {
            var stm = context.GetAs<ModelStateMachine>();

            var model = stm.Model;

            model.CleanEnd();
        }
    }
}