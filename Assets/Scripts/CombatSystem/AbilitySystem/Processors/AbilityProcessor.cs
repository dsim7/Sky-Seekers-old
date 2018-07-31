using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityProcessor : ActionProcessor<Ability>
{
    public PriorityEvent<Ability> OnAbilityStart = new PriorityEvent<Ability>();
    public PriorityEvent<Ability> OnAbilityComplete = new PriorityEvent<Ability>();

    public override void ProcessCompleteEvents(Ability instance)
    {
        OnAbilityStart.Trigger(instance);
    }

    public override void ProcessStartEvents(Ability instance)
    {
        OnAbilityComplete.Trigger(instance);
    }
}
