using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AbilityProcessor : ActionProcessor
{
    private string[] _eventNames = { "OnStart", "OnComplete" };
    protected override string[] eventNames { get { return _eventNames; } set { _eventNames = value; } }

    public override void ProcessCompleteEvents(ActionInstance action)
    {
        Events["OnStart"].Trigger(action);
    }

    public override void ProcessStartEvents(ActionInstance action)
    {
        Events["OnComplete"].Trigger(action);
    }
}
