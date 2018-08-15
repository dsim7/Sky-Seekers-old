using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/TerrorSigil")]
public class TerrorSigil : SigilTemplate
{
    private ActionMod _mod;

    public override void ModifyCharacter(Character character)
    {
        _mod = new ActionMod(100, Effect);
        character.OnActionComplete.RegisterAction(_mod);
    }

    public override void UnmodifyCharacter(Character character)
    {
        if (_mod != null)
        {
            character.OnEnemyActionComplete.UnregisterAction(_mod);
        }
    }

    public void Effect(ActionInstance utility)
    {
        Debug.Log("Terror Sigil Effect");
    }
}
