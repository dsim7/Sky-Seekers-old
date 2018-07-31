using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InvSlotScript : MonoBehaviour
{
    private InvItem _representedItem;
    public InvItem RepresentedItem
    {
        get { return _representedItem; }

        set
        { 
            _representedItem = value;
            UpdateIcon();

            _slot.UpdateItemHeld(value);
        }
    }

    private InvSlot _slot;

    public void LinkToSlot(InvSlot slot)
    {
        _slot = slot;
        if (slot != null)
        {
            slot.RegisterAction(UpdateRepresentedItem);
        }
        UpdateRepresentedItem();
    }

    public void UnlinkToSlot()
    {
        if (_slot != null)
        {
            _slot.UnregisterAction(UpdateRepresentedItem);
        }
        _slot = null;
        UpdateRepresentedItem();
    }
    
    // Sets represented item without invoking listeners
    public void UpdateRepresentedItem()
    {
        _representedItem = _slot != null ? _slot.Value : null;
        UpdateIcon();
    }

    void UpdateIcon()
    {
        MakeVisible(_representedItem != null);
        GetComponent<Image>().sprite = _representedItem != null ? _representedItem.Template.Icon : null;
    }

    void MakeVisible(bool visible)
    {
        Image image = GetComponent<Image>();
        Color newColor = image.color;
        newColor.a = visible ? 1f : 0f;
        image.color = newColor;
    }








    
}
