using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Targeting/Self")]
public class TargetingSelf : Targeting
{
    public override CombatCharacterScript GetTarget(CombatCharacterScript user, TeamScript team)
    {
        return user;
    }
}
