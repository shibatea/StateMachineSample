using System;

namespace StateMachineSample.Lib.Common
{
    public static class Messenger
    {
        public static Action<string> OnMessageReceived;

        public static void Send(string message)
        {
            OnMessageReceived?.Invoke(message);
        }
    }
}