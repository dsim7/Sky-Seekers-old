using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PriorityAction<T> : IComparable<PriorityAction<T>>  {

    public int Priority { get; set; }
    public UnityAction<T> Action { get; set; }

    public PriorityAction(int priority, UnityAction<T> action)
    {
        Priority = priority;
        Action = action;
    }

    public int CompareTo(PriorityAction<T> other)
    {
        return Priority.CompareTo(other.Priority);
    }

    public void Invoke(T param)
    {
        Action.Invoke(param);
    }
	
}
