using StateMachineSample.Lib.StateMachines.Application.Effect;

namespace StateMachineSample.Lib.StateMachines.Application.Trigger
{
    public sealed class SwitchStopTrigger : Common.Trigger
    {
        public SwitchStopTrigger() : base("Switch Stop Trigger", SwitchStopEffect.Instance)
        {
        }

        public static SwitchStopTrigger Instance { get; } = new SwitchStopTrigger();
    }
}