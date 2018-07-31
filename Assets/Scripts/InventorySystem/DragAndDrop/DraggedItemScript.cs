
using UnityEngine;
using UnityEngine.UI;

public class DraggedItemScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _canvas;
    [SerializeField]
    private DraggedItem _dragItem;

    private Canvas _canvasComponent;
    private Image _imageComponent;

    private bool _dragging = false;

    void Start()
    {
        _canvasComponent = _canvas.GetComponent<Canvas>();
        _imageComponent = GetComponent<Image>();

        _dragItem.RegisterAction(DragEvent);
    }

    void OnDestroy()
    {
        _dragItem.UnregisterAction(DragEvent);
    }

    void Update()
    {
        if (_dragging)
        {
            MoveToMouse();
        }
    }

    public void DragEvent()
    {
        InvItem draggedItem = _dragItem.Value;
        _imageComponent.enabled = draggedItem != null;
        _dragging = draggedItem != null;
        
        if (draggedItem != null)
        {
            UpdateSprite();

            MoveToMouse();

        }
    }
    
    void UpdateSprite()
    {
        _imageComponent.sprite = _dragItem.Value.Template.Icon;
    }

    void MoveToMouse()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform,
            Input.mousePosition, _canvasComponent.worldCamera,
            out movePos);

        transform.position = _canvas.transform.TransformPoint(movePos);

    }
}
