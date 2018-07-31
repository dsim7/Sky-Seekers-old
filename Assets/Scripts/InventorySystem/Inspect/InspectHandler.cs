using UnityEngine;

public abstract class InspectHandler : MonoBehaviour {

    [SerializeField]
    private InspectedItem _inspectedItem;

    protected void ShowInfoDisplay(GameObject objectToInspect)
    {
        _inspectedItem.Value = objectToInspect;
    }

    protected void HideInfoDisplay()
    {
        _inspectedItem.Value = null;
    }
}
