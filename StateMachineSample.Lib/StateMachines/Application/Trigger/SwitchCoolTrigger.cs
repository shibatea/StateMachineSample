namespace StateMachineSample.Lib.StateMachines.Application.Trigger
{
    public sealed class SwitchCoolTrigger : Common.Trigger
    {
        public SwitchCoolTrigger() : base("Switch Cool Trigger")
        {
        }

        public static SwitchCoolTrigger Instance { get; } = new SwitchCoolTrigger();
    }
}