namespace StateMachineSample.Lib.StateMachines.Common
{
    public abstract class Trigger
    {
        protected Trigger(string name, Effect effect = null)
        {
            Name = name;

            Effect = effect;
        }

        public string Name { get; }

        public Effect Effect { get; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}