namespace StateMachineSample.Lib.StateMachines.Application.Trigger
{
    public sealed class SwitchCleanTrigger : Common.Trigger
    {
        public SwitchCleanTrigger() : base("Switch Clean Trigger")
        {
        }

        public static SwitchCleanTrigger Instance { get; } = new SwitchCleanTrigger();
    }
}