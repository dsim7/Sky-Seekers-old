//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//[CreateAssetMenu]
//public class AbilityTemplate : ActionTemplate<Ability>
//{
//    //private Ability _attack = null;
//    //public override Ability ActionInstance { get { return _attack; } set { _attack = value; } }

//    [SerializeField]
//    private CooldownHandler _cooldown;
//    public override CooldownHandler Cooldown { get { return _cooldown; } set { _cooldown = value; } }

//    [SerializeField]
//    private AbilityEffector _effector;
//    public override ActionEffector<Ability> Effector { get { return _effector; } set { _effector = (AbilityEffector) value; } }
    
//    private ActionProcessor<Ability> _processor = new AbilityProcessor();
//    public override ActionProcessor<Ability> Processor { get { return _processor; } set { _processor = value; } }

//    protected override Ability Initialize(Character user, Character target)
//    {
//        Debug.Log(((BasicCooldownHandler)Cooldown).TimeRemaining);
//        if (Cooldown.OffCooldown()/* && ActionInstance == null*/)
//        {
//            Ability newAbility = new Ability();
//            newAbility.User = user;
//            newAbility.Target = target;
//            newAbility.Template = this;
//            return newAbility;
//        }
//        return null;
//    }
//}




//    //[SerializeField]
//    //private AbilityEvent _abilityEvent;

//    //public override void ActionEffect()
//    //{
//    //    _abilityEvent.Invoke(ActionInstance);
//    //}

//    //public PriorityEvent<Ability> OnAbilityStart = new PriorityEvent<Ability>();
//    //public PriorityEvent<Ability> OnAbilityComplete = new PriorityEvent<Ability>();

//    //public override void GenerateAbility(Character caster, Character target)
//    //{
//    //    CurrentAbility = new Ability();
//    //    CurrentAbility.User = caster;
//    //    CurrentAbility.Target = target;
//    //}

//    //public override void ProcessCompleteEvents()
//    //{
//    //    OnAbilityStart.Trigger(ActionInstance);
//    //}

//    //public override void ProcessStartEvents()
//    //{
//    //    OnAbilityComplete.Trigger(ActionInstance);
//    //}

////}

////[Serializable]
////public class AbilityEvent : UnityEvent<Ability>
////{

////}
