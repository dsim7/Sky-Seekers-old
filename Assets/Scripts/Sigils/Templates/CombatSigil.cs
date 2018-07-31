using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/CombatSigil")]
public class CombatSigil : SigilTemplate
{
    private PriorityAction<Attack> _mod;

    public override void ModifyCharacter(Character character)
    {
        _mod = new PriorityAction<Attack>(10, Effect);
        ((AttackProcessor) character.LightAttack.Processor).OnAttackHit.RegisterAction(_mod);
    }

    public override void UnmodifyCharacter(Character character)
    {
        if (_mod != null)
        {
            ((AttackProcessor)character.LightAttack.Processor).OnAttackHit.UnregisterAction(_mod);
        }
    }

    public void Effect(Attack attack)
    {
        Debug.Log("Combat Sigil");
        attack.Damage *= 2;
    }

}
