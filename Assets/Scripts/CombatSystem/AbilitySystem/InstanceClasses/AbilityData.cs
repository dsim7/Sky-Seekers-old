//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//public class AbilityData : ActionData
//{
//    public UnityEvent AbilityEffect { get; set; }
//}

//public abstract class Action<T>
//{
//    public Character User { get; set; }
//    public Character Target { get; set; }


//    public abstract ActionEffector<T> Effector { get; set; }
//}

//public class Ability : Action<Ability>
//{

//    public Character User { get; set; }
//    public Character Target { get; set; }
//    public ActionTemplate Template { get; set; }

//    public float Speed { get; set; }

//    public override ActionEffector<Ability> Effector { get; set; }
//    public ActionProcessor<object> Processor { get; set; }

//    public void ProcessStart()
//    {
//        Processor.ProcessStartEvents(this);
//    }

//    public void ProcessComplete()
//    {
//        Processor.ProcessCompleteEvents(this);
//    }

//    public void Effect()
//    {
//        Effector.Effect(this);
//    }
//}
