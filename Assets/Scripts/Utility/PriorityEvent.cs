using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityEvent<T> {

    private List<PriorityAction<T>> Actions = new List<PriorityAction<T>>();
    
    public void Trigger(T param)
    {
        Actions.ForEach(action => action.Invoke(param));
    }

    public void RegisterAction(PriorityAction<T> action)
    {
        AddSorted(action);
    }

    public void UnregisterAction(PriorityAction<T> action)
    {
        Actions.Remove(action);
    }

    void AddSorted(PriorityAction<T> item)
    {
        if (Actions.Count == 0)
        {
            Actions.Add(item);
            return;
        }
        if (Actions[Actions.Count - 1].CompareTo(item) <= 0)
        {
            Actions.Add(item);
            return;
        }
        if (Actions[0].CompareTo(item) >= 0)
        {
            Actions.Insert(0, item);
            return;
        }
        int index = Actions.BinarySearch(item);
        if (index < 0)
            index = ~index;
        Actions.Insert(index, item);
    }

}
