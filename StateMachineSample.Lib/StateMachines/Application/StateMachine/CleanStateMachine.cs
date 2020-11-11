using StateMachineSample.Lib.Model;
using StateMachineSample.Lib.StateMachines.Application.State;

namespace StateMachineSample.Lib.StateMachines.Application.StateMachine
{
    public class CleanStateMachine : Common.StateMachine
    {
        public CleanStateMachine(ModelStateMachine parent)
        {
            Parent = parent;

            Model = parent.Model;

            ChangeToInitialState();
        }

        public ModelStateMachine Parent { get; }

        public AirConditioner Model { get; }

        protected override Common.State GetInitialState()
        {
            return StainLevelAnalysisState.Instance;
        }
    }
}