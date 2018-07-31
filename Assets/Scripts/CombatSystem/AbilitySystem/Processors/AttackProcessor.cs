using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProcessor : ActionProcessor<Attack>
{
    public PriorityEvent<Attack> OnAttackStart = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnAttackConnect = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnAttackDefended = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnAttackMiss = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnAttackHit = new PriorityEvent<Attack>();

    public override void ProcessStartEvents(Attack instance)
    {
        Character attacker = instance.User;
        Character target = instance.Target;

        Debug.Log("Attack Start. Target: " + target);
        OnAttackStart.Trigger(instance);
        attacker.OnAttackStart.Trigger(instance);
        target.OnEnemyAttackStart.Trigger(instance);
    }

    public override void ProcessCompleteEvents(Attack instance)
    {
        Character attacker = instance.User;
        Character target = instance.Target;

        // Connect events
        Debug.Log("Attack Connect");
        OnAttackConnect.Trigger(instance);
        attacker.OnAttackConnect.Trigger(instance);
        target.OnEnemyAttackConnect.Trigger(instance);

        // Determine defended
        if (target.IsDefending)
        {
            // Defended events
            Debug.Log("Attack Defended");
            OnAttackDefended.Trigger(instance);
            attacker.OnAttackDefended.Trigger(instance);
            target.OnEnemyAttackDefended.Trigger(instance);
        }

        // Determine if attack misses
        if (instance.Miss)
        {
            // Miss events
            Debug.Log("Attack Miss");
            OnAttackMiss.Trigger(instance);
            attacker.OnAttackMiss.Trigger(instance);
            target.OnEnemyAttackMiss.Trigger(instance);
        }
        else
        {
            // Hit events
            Debug.Log("Attack Hit");
            OnAttackHit.Trigger(instance);
            attacker.OnAttackHit.Trigger(instance);
            target.OnEnemyAttackHit.Trigger(instance);
        }
    }
}