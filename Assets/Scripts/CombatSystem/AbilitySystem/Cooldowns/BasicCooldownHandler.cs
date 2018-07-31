using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BasicCooldownHandler : CooldownHandler
{
    public override bool OffCooldown()
    {
        return true;
    }

    public override void StartCooldown()
    {
        
    }
}
