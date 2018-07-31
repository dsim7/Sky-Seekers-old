using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Inventory")]
public class Inventory : ScriptableObject
{

    [SerializeField]
    private List<InvSlot> _slots = new List<InvSlot>();
    public List<InvSlot> Slots { get { return _slots; } }

    public void AddToFirstEmpty(Sigil itemToAdd)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].Value == null)
            {
                _slots[i].Value = itemToAdd;
            }
        }
    }

    void OnEnable()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i] == null)
            {
                _slots[i] = ScriptableObject.CreateInstance<InvSlot>();
            }
        }
    }

}
