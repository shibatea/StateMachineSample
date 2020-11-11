using StateMachineSample.Lib.Model;
using StateMachineSample.Lib.StateMachines.Application.StateMachine;
using StateMachineSample.Lib.StateMachines.Common;

namespace StateMachineSample.Lib.StateMachines.Application.State
{
    public sealed class StainLevelAnalysisState : Common.State
    {
        private StainLevelAnalysisState() : base("Stain Level AnalysisState")
        {
            OnDo = DoEventHandler;
        }

        public static StainLevelAnalysisState Instance { get; } = new StainLevelAnalysisState();

        protected override TriggerActionMap TriggerActionMap => new TriggerActionMap();

        private void DoEventHandler(Common.StateMachine context)
        {
            var stm = context.GetAs<CleanStateMachine>();

            var model = stm.Model;

            var level = model.StainLevelAnalys();

            switch (level)
            {
                case StainLevel.Unknown:
                    /* Nothing to do */
                    break;
                case StainLevel.Low:
                    stm.ChangeState(LightCleanState.Instance);
                    break;
                case StainLevel.High:
                    stm.ChangeState(DeepCleanState.Instance);
                    break;
            }
        }
    }
}