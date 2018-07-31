using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ActionTemplate<T> : ScriptableObject where T : Ability, new()
{
    public abstract T ActionInstance { get; set; }

    public abstract CooldownHandler Cooldowner { get; set; }

    public abstract ActionProcessor<T> Processor { get; set; } 

    public abstract ActionEffector<T> Effector { get; set; }

    public virtual void Initialize(Character user, Character target)
    {
        Debug.Log("Initialization: " + Cooldowner.OffCooldown() + " " + ActionInstance);
        if (Cooldowner.OffCooldown() && ActionInstance == null)
        {
            Debug.Log("Got in");
            ActionInstance = new T();
            ActionInstance.User = user;
            ActionInstance.Target = target;
        }
    }

    public void StartAction()
    {
        if (ActionInstance != null)
        {
            Processor.ProcessStartEvents(ActionInstance);
        }
    }

    public void CompleteAction()
    {
        if (ActionInstance != null)
        {
            Processor.ProcessCompleteEvents(ActionInstance);
            Effector.Effect(ActionInstance);
            Cooldowner.StartCooldown();
            ActionInstance = null;
        }
    }
}