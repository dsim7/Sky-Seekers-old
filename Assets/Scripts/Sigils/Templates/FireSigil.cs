using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/Templates/FireSigil")]
public class FireSigil : SigilTemplate
{
    private PriorityAction<Attack> _mod;

    public override void ModifyCharacter(Character character)
    {
        _mod = new PriorityAction<Attack>(10, Effect);
        //character.HeavyAttack.OnAttackHit.RegisterAction(_mod);
    }

    public override void UnmodifyCharacter(Character character)
    {
        if (_mod != null)
        {
            //character.HeavyAttack.OnAttackHit.UnregisterAction(_mod);
        }
    }

    public void Effect(Attack attack)
    {
        Debug.Log("Fire Sigil Effect");
    }
}
