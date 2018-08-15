using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionModEvent
{
    private List<ActionMod> Mods = new List<ActionMod>();

    public void Trigger(ActionInstance param)
    {
        for (int i = 0; i < Mods.Count; i++)
        {
            Mods[i].Mod(param);
        }
    }

    public void RegisterAction(ActionMod action)
    {
        AddSorted(action);
    }

    public void UnregisterAction(ActionMod action)
    {
        Mods.Remove(action);
    }

    void AddSorted(ActionMod item)
    {
        if (Mods.Count == 0)
        {
            Mods.Add(item);
            return;
        }
        if (Mods[Mods.Count - 1].CompareTo(item) <= 0)
        {
            Mods.Add(item);
            return;
        }
        if (Mods[0].CompareTo(item) >= 0)
        {
            Mods.Insert(0, item);
            return;
        }
        int index = Mods.BinarySearch(item);
        if (index < 0)
            index = ~index;
        Mods.Insert(index, item);
    }

}
