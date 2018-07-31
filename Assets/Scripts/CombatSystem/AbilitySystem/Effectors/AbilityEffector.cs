using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class AbilityEffector : ActionEffector<Ability>
{
    public AbilityEvent AbilityEvent;

    public override void Effect(Ability instance)
    {
        AbilityEvent.Invoke(instance);
    }
}

[Serializable]
public class AbilityEvent : UnityEvent<Ability> { }
