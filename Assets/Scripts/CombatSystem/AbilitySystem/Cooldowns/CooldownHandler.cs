using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class CooldownHandler : ScriptableObject
{
    [SerializeField]
    private float _cooldown;
    public float Cooldown { get { return _cooldown; } set { _cooldown = value; } }

    public abstract bool OffCooldown();

    public abstract void StartCooldown();
}
