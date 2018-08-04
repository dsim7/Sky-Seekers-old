using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTemplate
{
    [SerializeField]
    private CooldownHandler _cooldown;
    public CooldownHandler Cooldown { get { return _cooldown; } private set { _cooldown = value; } }

    [SerializeField]
    private ActionProcessor _processor;
    public ActionProcessor Processor { get { return _processor; } private set { _processor = value; } }

    [SerializeField]
    private ActionEffector _effector;
    public ActionEffector Effector { get { return _effector; } private set { _effector = value; } }

    [SerializeField]
    private ActionInitializer _initializer;
    public ActionInitializer Initializer { get { return _initializer; } private set { _initializer = value; } }

    public void ExecuteAction(Character user, Character target)
    {
        if (_cooldown.OffCooldown())
        {
            ActionInstance newAction = new ActionInstance(Initializer, Effector, Processor, Cooldown);
            newAction.Start(user, target);
        }
    }
}

//public class AttackTemplate : ActionTemplate<AttackData>
//{
//    [SerializeField]
//    private ActionProcessor<AttackData> _processor;
//    public override ActionProcessor<AttackData> Processor { get { return _processor; } set { _processor = value; } }

//    [SerializeField]
//    private ActionEffector<AttackData> _effector = new AttackEffector();
//    public override ActionEffector<AttackData> Effector { get { return _effector; } set { _effector = value; } }

//    [SerializeField]
//    private ActionInitializer<AttackData> _initializer = new AttackInitializer();
//    public override ActionInitializer<AttackData> Initializer { get { return _initializer; } set { _initializer = value; } }
    
//}

//public class AbilityTemplate : ActionTemplate<AbilityData>
//{
//    [SerializeField]
//    private ActionProcessor<AbilityData> _processor;
//    public override ActionProcessor<AbilityData> Processor { get { return _processor; } set { _processor = value; } }

//    [SerializeField]
//    private ActionEffector<AbilityData> _effector = new AbilityEffector();
//    public override ActionEffector<AbilityData> Effector { get { return _effector; } set { _effector = value; } }

//    [SerializeField]
//    private ActionInitializer<AbilityData> _initializer = new AbilityInitializer();
//    public override ActionInitializer<AbilityData> Initializer { get { return _initializer; } set { _initializer = value; } }

//}
