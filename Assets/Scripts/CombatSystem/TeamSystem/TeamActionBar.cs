using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamActionBar : MonoBehaviour
{
    [SerializeField]
    private ActionTemplateScript[] _buttons;

    public void UpdateButtons(Character main, Character support)
    {
        _buttons[0].Template = main.LightAttack;
        _buttons[1].Template = main.HeavyAttack;
        _buttons[2].Template = main.SpecialAttack;
        _buttons[3].Template = support.SupportAbility;
        _buttons[4].Template = main.DefensiveAbility;
    }
}
