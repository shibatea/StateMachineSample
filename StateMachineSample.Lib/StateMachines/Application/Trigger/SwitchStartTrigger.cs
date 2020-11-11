using StateMachineSample.Lib.StateMachines.Application.Effect;

namespace StateMachineSample.Lib.StateMachines.Application.Trigger
{
    public sealed class SwitchStartTrigger : Common.Trigger
    {
        public SwitchStartTrigger() : base("Switch Start Trigger", SwitchStartEffect.Instance)
        {
        }

        public static SwitchStartTrigger Instance { get; } = new SwitchStartTrigger();
    }
}