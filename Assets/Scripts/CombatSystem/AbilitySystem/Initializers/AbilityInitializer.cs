using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class AbilityInitializer : ActionInitializer
{
    public UnityEvent AbilityEffect;

    public override void InitializeData(ActionInstance action)
    {
        base.InitializeData(action);
        action.Effect = AbilityEffect;
    }

    //public override void InitializeData(Character user, Character target)
    //{
    //    AbilityData newAbility = new AbilityData();
    //    newAbility.User = user;
    //    newAbility.Target = target;
    //    newAbility.AbilityEffect = AbilityEffect;
    //    newAbility.Animation = Animation;
    //    newAbility.Speed = Speed;
    //    Action = newAbility;
    //}
}
