using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackProcessor : ActionProcessor
{
    private string[] _eventNames = { "OnAttackStart", "OnAttackConnect", "OnAttackDefended",
                                     "OnAttackMiss", "OnAttackHit" };
    protected override string[] eventNames { get { return _eventNames; } set { _eventNames = value; } }

    public override void ProcessStartEvents(ActionInstance Action)
    {
        Character attacker = Action.User;
        Character target = Action.Target;

        Debug.Log("Attack Start. Target: " + target);
        Events["OnAttackStart"].Trigger(Action);
        attacker.OnAttackStart.Trigger(Action);
        target.OnEnemyAttackStart.Trigger(Action);
    }

    public override void ProcessCompleteEvents(ActionInstance Action)
    {
        Character attacker = Action.User;
        Character target = Action.Target;

        // Connect events
        Debug.Log("Attack Connect");
        Events["OnAttackConnect"].Trigger(Action);
        attacker.OnAttackConnect.Trigger(Action);
        target.OnEnemyAttackConnect.Trigger(Action);

        // Determine defended
        if (target.IsDefending)
        {
            // Defended events
            Debug.Log("Attack Defended");
            Events["OnAttackDefended"].Trigger(Action);
            attacker.OnAttackDefended.Trigger(Action);
            target.OnEnemyAttackDefended.Trigger(Action);
        }

        // Determine if attack misses
        if (Action.Miss)
        {
            // Miss events
            Debug.Log("Attack Miss");
            Events["OnAttackMiss"].Trigger(Action);
            attacker.OnAttackMiss.Trigger(Action);
            target.OnEnemyAttackMiss.Trigger(Action);
        }
        else
        {
            // Hit events
            Debug.Log("Attack Hit");
            Events["OnAttackHit"].Trigger(Action);
            attacker.OnAttackHit.Trigger(Action);
            target.OnEnemyAttackHit.Trigger(Action);
        }
    }
}