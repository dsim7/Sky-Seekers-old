using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMoverScript), typeof(Animator))]
public class CombatCharacterScript : MonoBehaviour
{
    [SerializeField]
    private Character _character;
    public Character Character { get { return _character; } set { _character = value; } }
    [SerializeField]
    private TransformPool _floatingTextSfx;

    private ActionInstance _actionBeingExecuted;

    private Animator _animator;
    private CharacterMoverScript _mover;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<CharacterMoverScript>();

        _character.OnDeath.AddListener(Die);
        _character.OnActionStart.RegisterAction(new ActionMod(10000, StartAnimateAction));
        //_character.OnEnemyActionComplete.RegisterAction(new ActionMod(10000, TakeDamage));
        _character.RegisterMods();
    }
    
    void Update()
    {
        UpdateEffects();
    }

    public void StartAnimateAction(ActionInstance action)
    {    
        _actionBeingExecuted = action;

        // animate
        _animator.SetFloat("AttackSpeed", action.AnimationSpeed);
        _animator.SetTrigger(action.Animation);

        // Move character to attack position if the attack says to
        if (_mover != null && action.MoveToAttackPosition)
        {
            _mover.GoToAttackPosition();
        }
    }

    public void InterruptAnimateAction()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            _animator.SetTrigger("Idle");
        }
        _actionBeingExecuted = null;
    }

    public void CompleteAnimateAction()
    {
        // Action Complete callback
        if (_actionBeingExecuted != null)
        {
            _actionBeingExecuted.Template.CompleteAction(_actionBeingExecuted);
        }

        // Action sfx's
        if (_actionBeingExecuted.UserSfx != null)
        {
            ParticleSystem sfx = _actionBeingExecuted.UserSfx.GetNext();
            AttachSpecialEffect(sfx);
        }
        if (_actionBeingExecuted.TargetSfx != null)
        {
            ParticleSystem sfx = _actionBeingExecuted.TargetSfx.GetNext();
            _actionBeingExecuted.Target.AttachSpecialEffect(sfx);
        }

        // Move character back
        if (_mover != null && _actionBeingExecuted.MoveToAttackPosition)
        {
            _mover.GoBack();
        }

        // Reset action being executed
        _actionBeingExecuted = null;
    }

    public void AttachSpecialEffect(ParticleSystem sfx)
    {
        sfx.transform.SetParent(transform);
        sfx.transform.position = transform.position;
        sfx.Play();
    }

    public void DettachSpecialEffect(ParticleSystem sfx)
    {
        sfx.Stop();
    }

    public void TakeDamage(float amount, DamageType type)
    {
        if (!Character.IsDead && amount > 0)
        {
            Character.CurrentHealth -= amount;
            DisplayFloatingText(amount.ToString("#"), type.Color);
        }
    }

    public void TakeHealing(float amount)
    {
        if (amount > 0)
        {
            Character.CurrentHealth += amount;
            DisplayFloatingText(amount.ToString("#"), Color.green);
        }
    }

    void Die()
    {
        _actionBeingExecuted = null;
        _mover.GoToMainPosition();
        _character.Buffs.ForEach(buff => buff.RemoveEffect());
        _animator.SetTrigger("Death");
    }

    public void ExecuteAction(ActionTemplate template, TeamScript team)
    {
        if (!Character.IsDead &&
            !template.Targeting.GetTarget(this, team).Character.IsDead &&
            _actionBeingExecuted == null)
        {
            template.ExecuteAction(this, team);
        }
    }

    void DisplayFloatingText(string text, Color color)
    {
        Transform floatingTextObject = _floatingTextSfx.GetNext();
        FloatingText floatingText = floatingTextObject.GetComponentInChildren<FloatingText>();
        if (floatingText != null)
        {
            floatingText.Appear(transform, text, color);
        }
    }

    void UpdateEffects()
    {
        Character.Buffs.ForEach(buff => buff.CheckTime());
    }
}
