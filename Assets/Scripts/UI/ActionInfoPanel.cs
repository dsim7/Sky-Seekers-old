using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionInfoPanel : MonoBehaviour
{
    public void Display()
    {
        GetComponent<Animator>().SetTrigger("Appear");
    }

    public void Hide()
    {
        GetComponent<Animator>().SetTrigger("Disappear");
    }

    public void UpdateDisplay(Character character)
    {
        transform.GetChild(0).GetChild(2).GetComponent<Text>().text = character.LightAttack.Tooltip;
        transform.GetChild(1).GetChild(2).GetComponent<Text>().text = character.HeavyAttack.Tooltip;
        transform.GetChild(2).GetChild(2).GetComponent<Text>().text = character.SpecialAttack.Tooltip;
        transform.GetChild(3).GetChild(2).GetComponent<Text>().text = character.SupportAbility.Tooltip;
        transform.GetChild(4).GetChild(2).GetComponent<Text>().text = character.DefensiveAbility.Tooltip;
    }
}
