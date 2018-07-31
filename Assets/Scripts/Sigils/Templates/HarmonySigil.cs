using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/HarmonySigil")]
public class HarmonySigil : SigilTemplate
{
    private PriorityAction<AbilityTemplate> _mod;

    public override void ModifyCharacter(Character character)
    {
        _mod = new PriorityAction<AbilityTemplate>(10, Effect);
        //character.SupportAbility.OnCooldownStart.RegisterAction(_mod);
    }

    public override void UnmodifyCharacter(Character character)
    {
        if (_mod != null)
        {
            //character.SupportAbility.OnCooldownStart.UnregisterAction(_mod);
        }
    }

    public void Effect(AbilityTemplate utility)
    {
        Debug.Log("Harmony Sigil Effect");
    }
}
