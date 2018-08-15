using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionMod : IComparable<ActionMod>
{
    public int Priority { get; set; }
    public UnityAction<ActionInstance> Action { get; set; }

    public ActionMod(int priority, UnityAction<ActionInstance> action)
    {
        Priority = priority;
        Action = action;
    }

    public int CompareTo(ActionMod other)
    {
        return Priority.CompareTo(other.Priority);
    }

    public void Mod(ActionInstance param)
    {
        Action.Invoke(param);
    }
	
}
