using UnityEngine;

public class InvItemTemplate : ScriptableObject {

    public virtual string Name { get; set; }

    public virtual string Description { get; set; }

    public virtual Sprite Icon { get; set; }
}
