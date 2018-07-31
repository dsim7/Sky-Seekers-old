using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Inventory/Inventory Slot")]
public class InvSlot : ScriptableObject
{
    [SerializeField]
    private InvItem _value;
    public InvItem Value { get { return _value; } set { _value = value; _onChange.Invoke(); } }

    private UnityEvent _onChange = new UnityEvent();

    public void RegisterAction(UnityAction action)
    {
        _onChange.AddListener(action);
    }

    public void UnregisterAction(UnityAction action)
    {
        _onChange.RemoveListener(action);
    }

    public void UpdateItemHeld(InvItem item)
    {
        _value = item;
    }
}
//{
//    [SerializeField]
//    private InvItem _item;
//    public InvItem Item { get { return _item; } set { _item = value; ItemChanged.Invoke(value); } }

//    [HideInInspector]
//    public UnityEvent<InvItem> ItemChanged;

//    void OnEnable()
//    {
//        ItemChanged = new ItemEvent();
//    }
//}

//public class ItemEvent : UnityEvent<InvItem> { }
