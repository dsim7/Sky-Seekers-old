using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/FireSigil")]
public class FireSigil : SigilTemplate
{
    private ActionMod _mod;

    public override void ModifyCharacter(Character character)
    {
        _mod = new ActionMod(0, Effect);
        character.HeavyAttack.OnComplete.RegisterAction(_mod);
    }

    public override void UnmodifyCharacter(Character character)
    {
        if (_mod != null)
        {
            character.HeavyAttack.OnComplete.UnregisterAction(_mod);
        }
    }

    public void Effect(ActionInstance attack)
    {
        attack.User.Character.SpecialAttack.CooldownFinish = Time.time;
    }
}
