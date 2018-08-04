using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/TerrorSigil")]
public class TerrorSigil : SigilTemplate
{
    private PriorityAction<ActionInstance> _mod;

    public override void ModifyCharacter(Character character)
    {
        _mod = new PriorityAction<ActionInstance>(10, Effect);
        character.OnEnemyAttackDefended.RegisterAction(_mod);
    }

    public override void UnmodifyCharacter(Character character)
    {
        if (_mod != null)
        {
            character.OnEnemyAttackDefended.UnregisterAction(_mod);
        }
    }

    public void Effect(ActionInstance utility)
    {
        Debug.Log("Terror Sigil Effect");
    }
}
