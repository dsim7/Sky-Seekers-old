using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Combat/ActionTemplate")]
public class ActionTemplate : ScriptableObject
{
    private ActionModEvent _onStart = new ActionModEvent();
    public ActionModEvent OnStart { get { return _onStart; } private set { _onStart = value; } }
    
    private ActionModEvent _onComplete = new ActionModEvent();
    public ActionModEvent OnComplete { get { return _onComplete; } private set { _onComplete = value; } }

    [Header("Base Data")]
    [SerializeField]
    private ActionType _actionType = null;
    [SerializeField]
    private float _baseCooldown;
    public float Cooldown { get; set; }
    public float CooldownFinish { get; set; }
    private float _cooldownStart;
    public float CurrentCooldown { get { return (Time.time - _cooldownStart) / (CooldownFinish - _cooldownStart); } }
    [SerializeField]
    private Targeting _targeting;
    public Targeting Targeting { get { return _targeting; } }
    
    [Header("Effects")]
    [SerializeField]
    private UnityEvent _effect;
    [SerializeField]
    private float _duration = 0;
    [SerializeField]
    private float _effectIntensity = 1;

    [Header("Animations")]
    [SerializeField]
    private string _animation = "Attack";
    [SerializeField]
    private float _animationSpeed = 1f;
    [SerializeField]
    private bool _movesToAttackPosition = true;

    [Header("Special Effects")]
    [SerializeField]
    private ParticleSystemPool _userSfx;
    [SerializeField]
    private ParticleSystemPool _targetSfx;

    [Header("Damage")]
    [SerializeField]
    private DamageType _damageType;
    [SerializeField]
    private float _baseDamage = 0;

    [Header("Healing")]
    [SerializeField]
    private float _baseHealing = 0;

    void OnEnable()
    {
        _cooldownStart = 0;
        Cooldown = _baseCooldown;
        CooldownFinish = 0;
    }

    ActionInstance GenerateInstance()
    {
        ActionInstance newAction = new ActionInstance();

        // Initialize Data
        newAction.ActionType = _actionType;
        newAction.Effect = _effect;
        newAction.Duration = _duration;
        newAction.Animation = _animation;
        newAction.AnimationSpeed = _animationSpeed;
        newAction.DamageType = _damageType;
        newAction.Damage = _baseDamage;
        newAction.Healing = _baseHealing;
        newAction.EffectIntensity = _effectIntensity;
        newAction.UserSfx = _userSfx;
        newAction.TargetSfx = _targetSfx;
        newAction.MoveToAttackPosition = _movesToAttackPosition;

        return newAction;
    }

    public void ExecuteAction(CombatCharacterScript user, TeamScript team)
    {
        if (Time.time >= CooldownFinish)
        {
            ActionInstance action = GenerateInstance();
            action.User = user;
            action.Target = _targeting.GetTarget(user, team);
            action.Template = this;

            OnStart.Trigger(action);
            user.Character.OnActionStart.Trigger(action);
            action.Target.Character.OnEnemyActionStart.Trigger(action);
        }
    }

    public void CompleteAction(ActionInstance action)
    {
        // Event callbacks
        OnComplete.Trigger(action);
        action.User.Character.OnActionComplete.Trigger(action);
        action.Target.Character.OnEnemyActionComplete.Trigger(action);

        // Invoke effect
        action.Effect.Invoke();

        // Damage and healing
        action.Target.Character.CurrentHealth += action.Healing;
        Debug.Log("Damage Done: " + action.Damage);
        action.Target.Character.CurrentHealth -= action.Damage;

        // Start cooldown
        _cooldownStart = Time.time;
        CooldownFinish = Time.time + Cooldown;
    }
}
