using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacterScript : MonoBehaviour {

    [SerializeField]
    private Character _character;
    public Character Char { get { return _character; } set { _character = value; } }

    private PriorityAction<Attack> animateAttackAction;

    void Start()
    {
        animateAttackAction = new PriorityAction<Attack>(10000, AnimateAttack);
        _character.OnAttackStart.RegisterAction(animateAttackAction);
        _character.RegisterMods();
    }

    void AnimateAttack(Attack attack)
    {
        // animate
        Debug.Log("Animating Light Attack with speed: " + attack.Speed);
        Debug.Log("Animating Light Attack with cooldown: " + attack.Template.Cooldowner.Cooldown);

        attack.Template.CompleteAction();
    }
}
