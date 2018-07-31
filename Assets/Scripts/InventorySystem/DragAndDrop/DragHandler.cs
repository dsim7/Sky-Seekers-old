using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField]
    private DraggedItem _draggedItem;

    private InvSlotScript _invItemScript;

    void Start()
    {
        _invItemScript = GetComponent<InvSlotScript>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _draggedItem.Value = _invItemScript.RepresentedItem;

        GetComponent<CanvasGroup>().alpha = 0.5f;
            
        //_invItemScript.RepresentedItem = null;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        InvItem temp = _invItemScript.RepresentedItem;
        _invItemScript.RepresentedItem = _draggedItem.Value;
        _draggedItem.Value = temp;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _invItemScript.RepresentedItem = _draggedItem.Value;
        _draggedItem.Value = null;
        
        GetComponent<CanvasGroup>().alpha = 1f;
    }
}
