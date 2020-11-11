using System;
using System.Collections.Generic;

namespace StateMachineSample.Lib.StateMachines.Common
{
    public class TriggerActionMap : Dictionary<string, Action<TriggerActionArgs>>
    {
    }
}