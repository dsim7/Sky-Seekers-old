using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/TerrorSigil")]
public class TerrorSigil : SigilTemplate
{
    private PriorityAction<Attack> _mod;

    public override void ModifyCharacter(Character character)
    {
        _mod = new PriorityAction<Attack>(10, Effect);
        character.OnEnemyAttackDefended.RegisterAction(_mod);
    }

    public override void UnmodifyCharacter(Character character)
    {
        if (_mod != null)
        {
            character.OnEnemyAttackDefended.UnregisterAction(_mod);
        }
    }

    public void Effect(Attack utility)
    {
        Debug.Log("Terror Sigil Effect");
    }
}
