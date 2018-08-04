using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackEffector : ActionEffector
{
    public override void Effect(ActionInstance action)
    {
        Debug.Log("Attack deals " + action.Damage + " damage");
        action.Target.CurrentHealth -= action.Damage;
    }
}
