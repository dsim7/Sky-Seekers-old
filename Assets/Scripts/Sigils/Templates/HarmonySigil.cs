using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/HarmonySigil")]
public class HarmonySigil : SigilTemplate
{
    public override void ModifyCharacter(Character character)
    {
        character.SupportAbility.Cooldown.Cooldown *= 0.7f; 
    }

    public override void UnmodifyCharacter(Character character)
    {
        character.SupportAbility.Cooldown.Cooldown /= 0.7f;
    }
}
