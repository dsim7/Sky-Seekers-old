using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacterScript : MonoBehaviour
{
    [SerializeField]
    private Character _character;
    public Character Character { get { return _character; } set { _character = value; } }
    
    private PriorityAction<ActionInstance> _animateAttackAction;
    private ActionInstance _abilityBeingExecuted;

    private CharacterMoverScript _mover;

    void Start()
    {
        _mover = GetComponent<CharacterMoverScript>();

        _animateAttackAction = new PriorityAction<ActionInstance>(10000, StartAnimateAttack);
        _character.OnAttackStart.RegisterAction(_animateAttackAction);
        _character.RegisterMods();
    }

    void Update()
    {
        _character.UpdateCooldowns();
    }

    void StartAnimateAttack(ActionInstance attack)
    {
        _abilityBeingExecuted = attack;

        Character.IsUsingAbility = true;

        // animate
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("AttackSpeed", attack.Speed);
        animator.SetTrigger(attack.Animation);
        
        // move
        if (_mover != null)
        {
            _mover.GoToAttackPosition();
        }
    }

    public void AttackEffect()
    {
        _abilityBeingExecuted.Complete();
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
