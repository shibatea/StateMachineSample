namespace StateMachineSample.Lib.StateMachines.Application.Trigger
{
    public sealed class InitializedTrigger : Common.Trigger
    {
        public InitializedTrigger() : base("Initialized Trigger")
        {
        }

        public static InitializedTrigger Instance { get; } = new InitializedTrigger();
    }
}