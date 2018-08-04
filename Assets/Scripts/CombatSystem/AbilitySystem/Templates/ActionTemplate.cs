//using UnityEngine;

//public abstract class ActionTemplate : ScriptableObject
//{
//    [SerializeField]
//    private string _animationName;
//    public string AnimationName { get { return _animationName; } set { _animationName = value; } }

//    //protected abstract Ability Initialize(Character user, Character target);

//    public abstract void StartAction(Character user, Character target);

//    //public abstract void CompleteAction(Ability ability);
//}

//public abstract class ActionTemplate<T> : ActionTemplate where T : Ability, new()
//{
//    //public abstract T ActionInstance { get; set; }

//    public abstract CooldownHandler Cooldown { get; set; }

//    public abstract ActionEffector<T> Effector { get; set; }

//    public abstract ActionProcessor<T> Processor { get; set; }

//    protected abstract T Initialize(Character user, Character target);
//    //{
//    //    T newAction = new T();
//    //    newAction.Effector = Effector;
//    //    newAction.Processor = Processor;
//    //    return newAction;
//    //}

//    //{
//    //    //Debug.Log(((BasicCooldownHandler)Cooldowner).TimeRemaining);
//    //    if (Cooldown.OffCooldown())
//    //    {
//    //        T newAbility = new T();
//    //        newAbility.User = user;
//    //        newAbility.Target = target;
//    //        newAbility.Processor = Processor;
//    //        new
//    //        ActionInstance.User = user;
//    //        ActionInstance.Target = target;
//    //        ActionInstance.Template = this;
//    //        return true;
//    //    }
//    //    return false;
//    //}

//    public override void StartAction(Character user, Character target)
//    {
//        //if (Initialize(user, target))
//        //{
//        //    Processor.ProcessStartEvents(ActionInstance);
//        //}
//        T newAbility = Initialize(user, target);
//        if (newAbility != null)
//        {
//            newAbility.ProcessStart();
//        }
//    }

//    //public /*override*/ void CompleteAction(T ability)
//    //{
//    //    if (ability != null)
//    //    {
//    //        ability.ProcessComplete();
//    //        Cooldown.StartCooldown();
//    //    }
//    //}
//}