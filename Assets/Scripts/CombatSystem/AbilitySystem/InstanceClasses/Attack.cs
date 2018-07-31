using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Ability
{
    public AttackTemplate Template { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public bool Miss { get; set; }
}
