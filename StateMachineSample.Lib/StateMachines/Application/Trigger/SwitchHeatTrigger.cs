namespace StateMachineSample.Lib.StateMachines.Application.Trigger
{
    public sealed class SwitchHeatTrigger : Common.Trigger
    {
        public SwitchHeatTrigger() : base("Switch Heat Trigger")
        {
        }

        public static SwitchHeatTrigger Instance { get; } = new SwitchHeatTrigger();
    }
}