using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Buff : ScriptableObject
{
    public CombatCharacterScript Target { get; set; }
    public Buff OriginatingBuff { get; private set; }

    [Header("Power")]
    [SerializeField]
    private float _intensity;
    public float Intensity { get { return _intensity; } set { _intensity = value; } }
    [SerializeField]
    private DamageType _damageType;
    public DamageType DamageType { get { return _damageType; } set { _damageType = value; } }
    [SerializeField]
    private float _damage;
    public float Damage { get { return _damage; } set { _damage = value; } }
    [SerializeField]
    private float _healing;
    public float Healing { get { return _healing; } set { _healing = value; } }
    [SerializeField]
    private bool _stacks;
    public bool Stacks { get { return _stacks; } set { _stacks = value; } }

    [Header("Time")]
    [SerializeField]
    private float _tickRate;
    private float _timeOfNextTick;
    [SerializeField]
    private float _duration;
    public float StartTime { get; set; }
    public float FinishTime { get; set; }
    public float CurrentTime { get { return (Time.time - StartTime) / (FinishTime - StartTime); } }

    [Header("Special Effects")]
    [SerializeField]
    private ParticleSystemPool specialEffect;
    private ParticleSystem sfx;

    void OnEnable()
    {
        StartTime = 0;
        FinishTime = 0;
        _timeOfNextTick = 0;
    }

    public void CheckTime()
    {
        if (Time.time >= FinishTime)
        {
            RemoveEffect();
        }
        if (_tickRate != 0 && Time.time >= _timeOfNextTick)
        {
            OnTick();
            _timeOfNextTick += _tickRate;
        }
    }

    public void ApplyEffect(CombatCharacterScript target)
    {
        Buff preexistingBuff = target.Character.Buffs.Find(buff => buff.OriginatingBuff == this);
        if (preexistingBuff == null || Stacks)
        {
            Buff instance = Instantiate(this);
            instance.OriginatingBuff = this;

            instance.InitiateEffect(target);
        }
        else
        {
            preexistingBuff.FinishTime = Time.time + _duration;
        }
    }

    void InitiateEffect(CombatCharacterScript target)
    {
        StartTime = Time.time;
        FinishTime = StartTime + _duration;
        _timeOfNextTick = Time.time + _tickRate;

        Target = target;
        OnApply();
        Target.Character.Buffs.Add(this);

        sfx = specialEffect.GetNext(); 
        Target.AttachSpecialEffect(sfx);
    }

    public void RemoveEffect()
    {
        Target.DettachSpecialEffect(sfx);
        OnRemove();
        Target.Character.Buffs.Remove(this);
        Target = null;
    }

    protected abstract void OnApply();

    protected abstract void OnTick();

    protected abstract void OnRemove(); 
}
