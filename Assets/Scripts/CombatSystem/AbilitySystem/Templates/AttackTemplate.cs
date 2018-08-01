using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackTemplate : ActionTemplate<Attack>
{
    private Attack _attack = null;
    public override Attack ActionInstance { get { return _attack; } set { _attack = value; } }

    [SerializeField]
    private CooldownHandler _cooldown;
    public override CooldownHandler Cooldowner { get { return _cooldown; } set { _cooldown = value; } }

    [SerializeField]
    private AttackEffector _effector;
    public override ActionEffector<Attack> Effector { get { return _effector; } set { _effector = (AttackEffector) value; } }
    
    private ActionProcessor<Attack> _processor = new AttackProcessor();
    public override ActionProcessor<Attack> Processor { get { return _processor; } set { _processor = value; } }

    [SerializeField]
    private float _baseDamage;
    public float BaseDamage { get { return _baseDamage; } set { _baseDamage = value; } }

    [SerializeField]
    private float _baseSpeed;
    public float BaseSpeed { get { return _baseSpeed; } set { _baseSpeed = value; } }

    protected override bool Initialize(Character user, Character target)
    {
        if (Cooldowner.OffCooldown() && ActionInstance == null)
        {
            ActionInstance = new Attack();
            ActionInstance.User = user;
            ActionInstance.Target = target;
            ActionInstance.Template = this;
            ActionInstance.Damage = _baseDamage;
            ActionInstance.Speed = _baseSpeed;
            return true;
        }
        return false;
    }
}


    //[SerializeField]
    //private float _baseDamage;
    //public float BaseDamage { get { return _baseDamage; } set { _baseDamage = value; } }

    //[SerializeField]
    //private float _baseSpeed;
    //public float BaseSpeed { get { return _baseSpeed; } set { _baseSpeed = value; } }

    //public PriorityEvent<Attack> OnAttackStart = new PriorityEvent<Attack>();
    //public PriorityEvent<Attack> OnAttackConnect = new PriorityEvent<Attack>();
    //public PriorityEvent<Attack> OnAttackDefended = new PriorityEvent<Attack>();
    //public PriorityEvent<Attack> OnAttackMiss = new PriorityEvent<Attack>();
    //public PriorityEvent<Attack> OnAttackHit = new PriorityEvent<Attack>();

    //public override void GenerateAbility(Character caster, Character target)
    //{
    //    CurrentAbility = new Attack();
    //    CurrentAbility.User = caster;
    //    CurrentAbility.Target = target;
    //    CurrentAbility.Template = this;
    //    CurrentAbility.Damage = _baseDamage;
    //    CurrentAbility.Miss = false;
    //}

    //public override void ProcessStartEvents()
    //{
    //    Character attacker = ActionInstance.User;
    //    Character target = ActionInstance.Target;

    //    Debug.Log("Attack Start");
    //    OnAttackStart.Trigger(ActionInstance);
    //    attacker.OnAttackStart.Trigger(ActionInstance);
    //    target.OnEnemyAttackStart.Trigger(ActionInstance);
    //}

    //public override void ProcessCompleteEvents()
    //{
    //    Character attacker = ActionInstance.User;
    //    Character target = ActionInstance.Target;

    //    // Connect events
    //    Debug.Log("Attack Connect");
    //    OnAttackConnect.Trigger(ActionInstance);
    //    attacker.OnAttackConnect.Trigger(ActionInstance);
    //    target.OnEnemyAttackConnect.Trigger(ActionInstance);

    //    // Determine defended
    //    if (target.IsDefending)
    //    {
    //        // Defended events
    //        Debug.Log("Attack Defended");
    //        OnAttackDefended.Trigger(ActionInstance);
    //        attacker.OnAttackDefended.Trigger(ActionInstance);
    //        target.OnEnemyAttackDefended.Trigger(ActionInstance);
    //    }

    //    // Determine if attack misses
    //    if (ActionInstance.Miss)
    //    {
    //        // Miss events
    //        Debug.Log("Attack Miss");
    //        OnAttackMiss.Trigger(ActionInstance);
    //        attacker.OnAttackMiss.Trigger(ActionInstance);
    //        target.OnEnemyAttackMiss.Trigger(ActionInstance);
    //    }
    //    else
    //    {
    //        // Hit events
    //        Debug.Log("Attack Hit");
    //        OnAttackHit.Trigger(ActionInstance);
    //        attacker.OnAttackHit.Trigger(ActionInstance);
    //        target.OnEnemyAttackHit.Trigger(ActionInstance);
    //    }
    //}

    //public override void ActionEffect()
    //{
    //    ActionInstance.Target.CurrentHealth -= ActionInstance.Damage;
    //}
//}
