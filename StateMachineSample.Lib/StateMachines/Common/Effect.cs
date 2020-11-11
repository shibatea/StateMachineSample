using StateMachineSample.Lib.Common;

namespace StateMachineSample.Lib.StateMachines.Common
{
    public abstract class Effect
    {
        protected Effect(string name)
        {
            Name = name;
        }

        private string Name { get; }

        protected abstract void ExecuteAction(StateMachine context);

        public void Execute(StateMachine context)
        {
            Messenger.Send($"Execute : {Name}");

            ExecuteAction(context);
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}