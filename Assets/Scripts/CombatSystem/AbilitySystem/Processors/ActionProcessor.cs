

using System.Collections.Generic;
using UnityEngine;

public abstract class ActionProcessor : ScriptableObject
{
    protected abstract string[] eventNames { get; set; }

    protected Dictionary<string, PriorityEvent<ActionInstance>> Events = new Dictionary<string, PriorityEvent<ActionInstance>>();

    public ActionProcessor()
    {
        for (int i = 0; i < eventNames.Length; i++)
        {
            Events.Add(eventNames[i], new PriorityEvent<ActionInstance>());
        }
    }

    public abstract void ProcessStartEvents(ActionInstance action);

    public abstract void ProcessCompleteEvents(ActionInstance action);

    public bool Subscribe(string eventName, PriorityAction<ActionInstance> modifier)
    {
        if (Events[eventName] != null)
        {
            Events[eventName].RegisterAction(modifier);
            return true;
        }
        return false;
    }

    public void Unsubscribe(string eventName, PriorityAction<ActionInstance> modifier)
    {
        if (Events[eventName] != null)
        {
            Events[eventName].UnregisterAction(modifier);
        }
    }
}

//public abstract class ActionProcessor<T> : ActionProcessor
//{
//    public T Action { get; set; }
//}
