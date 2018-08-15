using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Targeting/Main")]
public class TargetingMain : Targeting
{
    public override CombatCharacterScript GetTarget(CombatCharacterScript user, TeamScript team)
    {
        return team.Main;
    }
}