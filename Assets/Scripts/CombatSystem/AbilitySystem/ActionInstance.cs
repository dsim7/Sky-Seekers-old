using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionInstance
{
    public ActionTemplate Template { get; set; }
    public CombatCharacterScript User { get; set; }
    public CombatCharacterScript Target { get; set; }

    public ActionType ActionType { get; set; }

    public UnityEvent Effect { get; set; }
    public string Animation { get; set; }
    public float AnimationSpeed { get; set; }
    public DamageType DamageType { get; set; }
    public float Damage { get; set; }
    public float Healing { get; set; }
    public bool Miss { get; set; }
    public float Duration { get; set; }
    public float EffectIntensity { get; set; }
    public ParticleSystemPool UserSfx { get; set; }
    public ParticleSystemPool TargetSfx { get; set; }
    public bool MoveToAttackPosition { get; set; }
}
