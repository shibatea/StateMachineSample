using StateMachineSample.Lib.Model;
using StateMachineSample.Lib.StateMachines.Application.State;

namespace StateMachineSample.Lib.StateMachines.Application.StateMachine
{
    public class ModelStateMachine : Common.StateMachine
    {
        public ModelStateMachine(AirConditioner model)
        {
            Model = model;

            ChangeToInitialState();
        }

        public AirConditioner Model { get; }

        protected override Common.State GetInitialState()
        {
            return InitialState.Instance;
        }
    }
}