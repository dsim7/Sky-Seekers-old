using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackInitializer : ActionInitializer
{
    public float BaseDamage { get; set; }

    public override void InitializeData(ActionInstance action)
    {
        base.InitializeData(action);
        action.Damage = BaseDamage;
    }

    //public override void InitializeData(Character user, Character target)
    //{
    //    AttackData newAttack = new AttackData();
    //    newAttack.User = user;
    //    newAttack.Target = target;
    //    newAttack.Speed = Speed;
    //    newAttack.Damage = BaseDamage;
    //    newAttack.Miss = false;
    //    newAttack.Animation = Animation;
    //    Action = newAttack;
    //}
}
