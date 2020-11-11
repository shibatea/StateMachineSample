using System;

namespace StateMachineSample.Lib.Common
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        private static readonly Lazy<T> LazySingleton = new Lazy<T>(() => new T());

        public static T Instance => LazySingleton.Value;
    }
}