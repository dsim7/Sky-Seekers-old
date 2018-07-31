using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class AttackEffector : ActionEffector<Attack>
{
    public override void Effect(Attack instance)
    {
        Debug.Log("Attack deals " + instance.Damage + " damage");
        instance.Target.CurrentHealth -= instance.Damage;
    }
}
