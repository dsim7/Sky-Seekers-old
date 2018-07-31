using UnityEngine;

public abstract class SigilTemplate : InvItemTemplate
{
    [SerializeField]
    private SigilTemplateSet templateSet;

    [Header("Attributes")]
    [SerializeField]
    private string _name;
    public override string Name { get { return _name; } set { _name = value; } }

    [SerializeField]
    private Sprite _icon;
    public override Sprite Icon { get { return _icon; } set { _icon = value; } }

    [TextArea(10, 15)]
    [SerializeField]
    private string _description;
    public override string Description { get { return _description; } set { _description = value; } }

    void OnEnable()
    {
        templateSet.Add(this);
    }

    void OnDisable()
    {
        templateSet.Remove(this);
    }
    
    public abstract void ModifyCharacter(Character character);

    public abstract void UnmodifyCharacter(Character character);
}
