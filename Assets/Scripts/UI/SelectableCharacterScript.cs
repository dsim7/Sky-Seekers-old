using UnityEngine;
using UnityEngine.Events;

public class SelectableCharacterScript : MonoBehaviour
{
    [SerializeField]
    private GameObject characterSelector;

    [SerializeField]
    private Character _character;
    public Character Char { get { return _character; } set { _character = value; } }
    
    private MenuCharacterSelect _charSelectorComponent;

    public RuntimeAnimatorController AnimController { get; private set; }

    void Start()
    {
        _charSelectorComponent = characterSelector.GetComponent<MenuCharacterSelect>();
        AnimController = GetComponent<Animator>().runtimeAnimatorController;
    }

    void OnMouseDown()
    {
        _charSelectorComponent.SelectCharacter(this);
    }
}
