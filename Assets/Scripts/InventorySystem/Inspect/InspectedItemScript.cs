using UnityEngine;
using UnityEngine.UI;

public class InspectedItemScript : MonoBehaviour
{
    [SerializeField]
    private InspectedItem _inspectedItem;

    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text descText;
    
    void Start()
    {
        _inspectedItem.RegisterAction(UpdateInfo);
    }

    void OnDestroy()
    {
        _inspectedItem.UnregisterAction(UpdateInfo);
    }

    void UpdateInfo()
    {
        GameObject inspectedItem = _inspectedItem.Value;
        if (inspectedItem != null)
        {
            InvSlotScript invItemScript = inspectedItem.GetComponent<InvSlotScript>();
            if (invItemScript != null && invItemScript.RepresentedItem != null)
            {
                nameText.text = invItemScript.RepresentedItem.Template.Name;
                descText.text = invItemScript.RepresentedItem.Template.Description;

                gameObject.SetActive(true);
                transform.position = inspectedItem.transform.position;
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    
}
