using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/CombatSigil")]
public class CombatSigil : SigilTemplate
{
    private ActionMod _mod;

    public override void ModifyCharacter(Character character)
    {
        _mod = new ActionMod(0, Effect);
        character.LightAttack.OnStart.RegisterAction(_mod);
    }

    public override void UnmodifyCharacter(Character character)
    {
        if (_mod != null)
        {
            character.LightAttack.OnStart.UnregisterAction(_mod);
        }
    }

    public void Effect(ActionInstance attack)
    {
        attack.Damage *= 1.3f;
        Debug.Log("Combat Sigil multiple attack: " + attack.Damage);
    }

}
