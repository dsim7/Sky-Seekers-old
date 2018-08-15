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
    
}
