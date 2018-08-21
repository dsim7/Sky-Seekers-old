using UnityEngine;

[CreateAssetMenu]
public class BuffBurning : Buff
{
    private float _currentAdditivePower = 0f;
    private float _additivePower = 0.25f;
    private float _maxAdditivePower = 3f;

    protected override void OnApply()
    {
        
    }

    protected override void OnTick()
    {
        Target.TakeDamage(Damage * (1 + _currentAdditivePower) * Intensity, DamageType);
        _currentAdditivePower = Mathf.Min(_currentAdditivePower + _additivePower, _maxAdditivePower);
    }

    protected override void OnRemove()
    {
        
    }
}
