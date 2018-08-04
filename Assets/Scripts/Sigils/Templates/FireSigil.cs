using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/FireSigil")]
public class FireSigil : SigilTemplate
{
    private PriorityAction<ActionInstance> _mod;

    public override void ModifyCharacter(Character character)
    {
        _mod = new PriorityAction<ActionInstance>(10, Effect);
        character.HeavyAttack.Processor.Subscribe("OnAttackHit", _mod);
    }

    public override void UnmodifyCharacter(Character character)
    {
        if (_mod != null)
        {
            character.HeavyAttack.Processor.Unsubscribe("OnAttackHit", _mod);
        }
    }

    public void Effect(ActionInstance attack)
    {
        Debug.Log("Fire Sigil Effect");
    }
}
