using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Targeting : ScriptableObject
{
    public abstract CombatCharacterScript GetTarget(CombatCharacterScript user, TeamScript team);
}
