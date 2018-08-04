using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class AbilityEffector : ActionEffector
{
    public override void Effect(ActionInstance action)
    {
        action.Effect.Invoke();
    }
}

//[Serializable]
//public class AbilityEvent : UnityEvent<AbilityData> { }
