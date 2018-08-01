using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacterScript : MonoBehaviour
{
    [SerializeField]
    private Character _character;
    public Character Character { get { return _character; } set { _character = value; } }
    
    private PriorityAction<Attack> _animateAttackAction;
    private Ability _abilityBeingExecuted;

    private CharacterMoverScript _mover;

    void Start()
    {
        _mover = GetComponent<CharacterMoverScript>();

        _animateAttackAction = new PriorityAction<Attack>(10000, StartAnimateAttack);
        _character.OnAttackStart.RegisterAction(_animateAttackAction);
        _character.RegisterMods();
    }

    void Update()
    {
        _character.UpdateCooldowns();
    }

    void StartAnimateAttack(Attack attack)
    {
        _abilityBeingExecuted = attack;

        Character.IsUsingAbility = true;

        // animate
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("AttackSpeed", attack.Speed);
        animator.SetTrigger(attack.Template.AnimationName);
        
        // move
        if (_mover != null)
        {
            _mover.GoToAttackPosition();
        }
    }

    public void AttackEffect()
    {
        _abilityBeingExecuted.Template.CompleteAction();
    }

    public void CompleteAnimateAttack()
    {
        Character.IsUsingAbility = false;

        // move
        if (_mover != null)
        {
            _mover.GoToHoldPosition();
        }
    }
}
