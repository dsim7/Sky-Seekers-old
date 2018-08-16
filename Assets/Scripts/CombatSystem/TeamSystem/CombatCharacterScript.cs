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
    private FloatingTextPool _floatingTextSfx;

    private ActionInstance _actionBeingExecuted;

    private Animator _animator;
    private CharacterMoverScript _mover;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<CharacterMoverScript>();

        _character.OnDeath.AddListener(Die);
        _character.OnActionStart.RegisterAction(new ActionMod(10000, StartAnimateAction));
        _character.OnEnemyActionComplete.RegisterAction(new ActionMod(10000, FloatingCombatTextDisplay));
        _character.RegisterMods();
    }
    
    public void StartAnimateAction(ActionInstance action)
    {    
        _actionBeingExecuted = action;

        // animate
        _animator.SetFloat("AttackSpeed", action.AnimationSpeed);
        _animator.SetTrigger(action.Animation);

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

    //public void CompleteAnimateAction()
    //{
    //    if (_mover != null && _actionBeingExecuted.MoveToAttackPosition)
    //    {
    //        _mover.GoBack();
    //    }

    //    _actionBeingExecuted = null;
    //}

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
            sfx.transform.SetParent(transform);
            sfx.transform.position = transform.position;
            sfx.Play();
        }
        if (_actionBeingExecuted.TargetSfx != null)
        {
            ParticleSystem sfx = _actionBeingExecuted.TargetSfx.GetNext();
            Debug.Log(sfx);
            sfx.transform.SetParent(_actionBeingExecuted.Target.transform);
            sfx.transform.position = _actionBeingExecuted.Target.transform.position;
            sfx.Play();
        }

        // Move character back
        if (_mover != null && _actionBeingExecuted.MoveToAttackPosition)
        {
            _mover.GoBack();
        }

        // Reset action being executed
        _actionBeingExecuted = null;
    }

    void Die()
    {
        _mover.GoToMainPosition();
        _animator.SetTrigger("Death");
        _actionBeingExecuted = null;
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

    public void FloatingCombatTextDisplay(ActionInstance action)
    {
        if (action.Damage > 0)
        {
            TextMesh floatingText = _floatingTextSfx.GetNext();
            floatingText.transform.SetParent(transform);
            floatingText.transform.position = transform.position;
            floatingText.text = action.Damage.ToString("#");
            floatingText.color = action.DamageType.Color;
            floatingText.GetComponent<Animator>().SetTrigger("Appear");
        }

        if (action.Healing > 0)
        {
            TextMesh floatingText = _floatingTextSfx.GetNext();
            floatingText.transform.SetParent(transform);
            floatingText.transform.position = transform.position;
            floatingText.text = action.Healing.ToString("#");
            floatingText.color = Color.green;
            floatingText.GetComponent<Animator>().SetTrigger("Appear");
        }
    }
}
