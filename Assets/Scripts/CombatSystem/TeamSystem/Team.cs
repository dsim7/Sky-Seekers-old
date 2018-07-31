using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Team : ScriptableObject
{

    [SerializeField]
    private Team _targetTeam;
    public Team TargetTeam { get { return _targetTeam; } set { _targetTeam = value; } }

    [SerializeField]
    private Character _main;
    public Character Main { get { return _main; } set { _main = value; } }

    [SerializeField]
    private Character _support;
    public Character Support { get { return _support; } set { _support = value; } }


    public void DoLightAttack()
    {
        Debug.Log("Team Light Attack");
        _main.DoLightAttack(Main, TargetTeam.Main);

    }

    //public void DoHeavyAttack()
    //{
    //    Debug.Log("Team Heavy Attack");
    //    _main.DoAttack(_main.HeavyAttack, this);

    //}

    //public void DoSpecialAttack()
    //{
    //    Debug.Log("Team Special Attack");
    //    _main.DoAttack(_main.SpecialAttack, this);

    //}

    //public void DoSupportAbility()
    //{
    //    Debug.Log("Team Support Ability");
    //    _support.DoUtility(_support.SupportAbility, this);

    //}

    //public void DoDefensiveAbility()
    //{
    //    Debug.Log("Team Defensive Ability");
    //    _main.DoUtility(_main.DefensiveAbility, this);

    //}
}
