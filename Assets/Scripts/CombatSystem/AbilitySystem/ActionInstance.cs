﻿
public class ActionInstance
{
    public ActionTemplate Template { get; set; }
    public CombatCharacterScript User { get; set; }
    public CombatCharacterScript Target { get; set; }

    public ActionType ActionType { get; set; }
    
    public string Animation { get; set; }
    public float AnimationSpeed { get; set; }
    public DamageType DamageType { get; set; }
    public float Damage { get; set; }
    public float Healing { get; set; }
    public bool Miss { get; set; }
    public Buff Buff { get; set; }
    public ParticleSystemPool UserSfx { get; set; }
    public ParticleSystemPool TargetSfx { get; set; }
    public bool MoveToAttackPosition { get; set; }
}
