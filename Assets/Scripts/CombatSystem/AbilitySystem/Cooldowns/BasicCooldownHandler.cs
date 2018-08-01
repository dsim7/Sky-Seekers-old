using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BasicCooldownHandler : CooldownHandler
{
    [SerializeField]
    private float _timeRemaining;
    public float TimeRemaining { get { return _timeRemaining; } set { _timeRemaining = value; } }

    public override bool OffCooldown()
    {
        return TimeRemaining <= 0;
    }

    public override void StartCooldown()
    {
        TimeRemaining = Cooldown;
    }

    public override void UpdateCooldown()
    {
        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
        }
    }
}
