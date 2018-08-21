using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCharacterSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraTarget;
    [SerializeField]
    private GameObject characterAvatar;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text attackText;
    [SerializeField]
    private Text armorText;
    [SerializeField]
    private GameObject characterEquipped;
    [SerializeField]
    private ActionInfoPanel actionInfoPanel;

    public bool IsSelecting { get; set; }

    private Animator panelAnimator;
    private Image avatarImage;

    void Start()
    {
        IsSelecting = false;
        panelAnimator = GetComponent<Animator>();
        avatarImage = characterAvatar.GetComponent<Image>();
    }

    void Update()
    {

    }
    
	public void InitCharacterSelect()
    {
        Animator cameraTargetAnimator = cameraTarget.GetComponent<Animator>(); 
        cameraTargetAnimator.SetTrigger("CharacterSelect");
        cameraTarget.GetComponent<CameraTarget>().transitionSpeed = 4f;
        IsSelecting = true;
    }

    public void SelectCharacter(SelectableCharacterScript selectedCharacter)
    {
        if (!panelAnimator.GetCurrentAnimatorStateInfo(0).IsName("In"))
        {
            panelAnimator.SetTrigger("In");
            actionInfoPanel.Display();
        } 

        // update panel values
        Character characterObject = selectedCharacter.Char;
        nameText.text = characterObject.Name;
        avatarImage.sprite = characterObject.Avatar;
        healthText.text = characterObject.Health.ToString("0");
        attackText.text = characterObject.AttackPower.ToString("0.#");
        armorText.text = characterObject.Armor.ToString("0.#");
        characterEquipped.GetComponent<InventoryScript>().Inventory = characterObject.Equipped;

        // display action info
        actionInfoPanel.UpdateDisplay(selectedCharacter.Char);

    }

    public void Hide()
    {
        panelAnimator.SetTrigger("Out");
    }
}
