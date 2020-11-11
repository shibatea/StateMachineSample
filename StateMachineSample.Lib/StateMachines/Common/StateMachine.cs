using System;
using StateMachineSample.Lib.Common;

namespace StateMachineSample.Lib.StateMachines.Common
{
    public abstract class StateMachine : NotificationObject
    {
        private State _currentState { get; set; }

        public State CurrentState
        {
            get => _currentState;
            set
            {
                if (_currentState == value) return;

                _currentState = value;
                RaisePropertyChanged(nameof(CurrentState));
            }
        }

        public State PreviousState { get; private set; }

        protected abstract State GetInitialState();

        public void SendTrigger(Trigger trigger)
        {
            Messenger.Send($"Send Trigger : {trigger.Name}");

            CurrentState?.SendTrigger(this, trigger);
        }

        public void ChangeState(State newState, Effect effect = null)
        {
            if (CurrentState != newState)
            {
                var oldState = CurrentState;

                CurrentState?.ExecuteExitAction(this);

                CurrentState = newState;
                PreviousState = oldState;

                if (oldState != null) Messenger.Send($"State Changed : {oldState} => {newState}");

                effect?.Execute(this);

                CurrentState?.ExecuteEntryAction(this);
            }
        }

        public void Update()
        {
            CurrentState?.ExecuteDoAction(this);
        }

        public T GetAs<T>() where T : StateMachine
        {
            if (this is T stm)
                return stm;
            throw new InvalidOperationException($"State Machine is not {nameof(T)}");
        }

        protected void ChangeToInitialState()
        {
            var initialState = GetInitialState();

            ChangeState(initialState);
        }
    }
}