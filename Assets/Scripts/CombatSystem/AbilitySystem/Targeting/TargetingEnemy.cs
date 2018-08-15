using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Targeting/Enemy")]
public class TargetingEnemy : Targeting
{
    public override CombatCharacterScript GetTarget(CombatCharacterScript user, TeamScript team)
    {
        return team.EnemyTeam.Main;
    }
}

