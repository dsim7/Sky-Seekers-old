using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;
    public Inventory Inventory { get { return _inventory; } set { _inventory = value; LinkSlots(); } }
    
    private InvSlotScript[] _slots;

    void Awake()
    {
        _slots = GetComponentsInChildren<InvSlotScript>();
    }

    void Start()
    {
        LinkSlots();
    }

    void LinkSlots()
    {
        List<InvSlot> inventorySlots = _inventory.Slots;

        // link slot scripts to slot objects; one to one
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].LinkToSlot(i < inventorySlots.Count ? inventorySlots[i] : null);
        }
    }

}
