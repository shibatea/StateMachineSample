namespace StateMachineSample.Lib.StateMachines.Application.Trigger
{
    public sealed class SwitchDryTrigger : Common.Trigger
    {
        public SwitchDryTrigger() : base("Switch Dry Trigger")
        {
        }

        public static SwitchDryTrigger Instance { get; } = new SwitchDryTrigger();
    }
}