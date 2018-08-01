using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class TeamController : ScriptableObject
{
    public Team Team;
    
    public void DoLightAttack()
    {
        Team.DoLightAttack();
    }

    public void DoHeavyAttack()
    {

    }

    public void DoSpecialAttack()
    {

    }

    public void DoDefensiveAbility()
    {

    }

    public void DoSupportAbility()
    {

    }


}
