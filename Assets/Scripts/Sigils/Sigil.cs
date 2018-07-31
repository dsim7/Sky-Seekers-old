using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Sigils/SigilObject")]
public class Sigil : InvItem
{
    [SerializeField]
    private InvItemTemplate _template;
    public override InvItemTemplate Template { get { return _template; } set { _template = value; } }

    [SerializeField]
    private int charges;

}

