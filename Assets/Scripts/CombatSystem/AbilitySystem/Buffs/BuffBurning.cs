using UnityEngine;

[CreateAssetMenu]
public class BuffBurning : Buff
{
    protected override void OnApply()
    {
        
    }

    protected override void OnTick()
    {
        Target.TakeDamage(Damage, DamageType);
    }

    protected override void OnRemove()
    {
        
    }
}
