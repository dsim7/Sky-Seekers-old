using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/CombatSigil")]
public class CombatSigil : SigilTemplate
{
    private PriorityAction<ActionInstance> _mod;

    public override void ModifyCharacter(Character character)
    {
        _mod = new PriorityAction<ActionInstance>(10, Effect);
        character.LightAttack.Processor.Subscribe("OnAttackHit", _mod);
    }

    public override void UnmodifyCharacter(Character character)
    {
        if (_mod != null)
        {
            character.LightAttack.Processor.Unsubscribe("OnAttackHit", _mod);
        }
    }

    public void Effect(ActionInstance attack)
    {
        Debug.Log("Combat Sigil");
        attack.Damage *= 2;
    }

}
