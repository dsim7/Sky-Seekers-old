using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class TeamController : ScriptableObject
{
    public Team team;

    public UnityEvent DoLightAttack;
    
    public UnityEvent DoHeavyAttack;
    
    public UnityEvent DoSpecialAttack;
    
    public UnityEvent DoDefensiveAbility;
    
    public UnityEvent DoSupportAbility;


}
