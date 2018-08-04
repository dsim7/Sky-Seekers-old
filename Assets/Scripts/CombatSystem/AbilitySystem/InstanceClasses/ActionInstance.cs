using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionInstance
{
    public Character User { get; set; }
    public Character Target { get; set; }

    // Data
    public UnityEvent Effect { get; set; }
    public string Animation { get; set; }
    public float Speed { get; set; }
    public float Damage { get; set; }
    public bool Miss { get; set; }

    // Components
    ActionInitializer _initializer;
    ActionEffector _effector;
    ActionProcessor _processor;
    CooldownHandler _cooldown;

    public ActionInstance(ActionInitializer initializer, ActionEffector effector, ActionProcessor processor,
        CooldownHandler cooldown)
    {
        _initializer = initializer;
        _effector = effector;
        _processor = processor;
        _cooldown = cooldown;
    }

    public void Start(Character user, Character target)
    {
        User = user;
        Target = target;
        _initializer.InitializeData(this);
        _processor.ProcessStartEvents(this);
    }

    public void Complete()
    {
        _processor.ProcessCompleteEvents(this);
        _effector.Effect(this);
        _cooldown.StartCooldown();
    }
}

//public class ActionInstance<T> : ActionInstance where T : new()
//{
//    protected T Action { get; set; }
    
//    public ActionInitializer<T> Initializer { get; private set; }
//    public ActionEffector<T> Effector { get; private set; }
//    public ActionProcessor<T> Processor { get; private set; }

//    //public ActionInstance(ActionInitializer<T> initializer, ActionEffector<T> effector,
//    //    ActionProcessor<T> processor)
//    //{
//    //    Initializer = initializer;
//    //    Action = Initializer.Action;

//    //    Effector = effector;
//    //    Effector.Action = Action;

//    //    Processor = processor;
//    //    Processor.Action = Action;
//    //}

//    public override void Initialize(Character user, Character target)
//    {
//        Initializer.InitializeData(user, target);
//        Action = Initializer.Action;
//    }

//    public override void ProcessComplete()
//    {
//        Processor.ProcessStartEvents();
//    }

//    public override void ProcessStart()
//    {
//        Processor.ProcessCompleteEvents();
//    }

//    public override void Effect()
//    {
//        Effector.Effect();
//    }
//}
