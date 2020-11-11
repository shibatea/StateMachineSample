using System;
using StateMachineSample.Lib.Common;

namespace StateMachineSample.Lib.StateMachines.Common
{
    public abstract class State
    {
        protected Action<StateMachine> OnDo;
        protected Action<StateMachine> OnEntry;
        protected Action<StateMachine> OnExit;

        protected State(string name)
        {
            Name = name;
        }

        public string Name { get; }

        protected abstract TriggerActionMap TriggerActionMap { get; }

        public void ExecuteEntryAction(StateMachine context)
        {
            Messenger.Send($"Entry : {Name}");

            OnEntry?.Invoke(context);
        }

        public void ExecuteDoAction(StateMachine context)
        {
            Messenger.Send($"Do : {Name}");

            OnDo?.Invoke(context);
        }

        public void ExecuteExitAction(StateMachine context)
        {
            Messenger.Send($"Exit : {Name}");

            OnExit?.Invoke(context);
        }

        public void SendTrigger(StateMachine context, Trigger trigger)
        {
            if (TriggerActionMap.ContainsKey(trigger.Name))
            {
                Messenger.Send($"Trigger : {trigger.Name}");

                var action = TriggerActionMap[trigger.Name];

                var args = new TriggerActionArgs(context, trigger);

                action(args);
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}