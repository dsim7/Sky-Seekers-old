using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCharacterSelect : MonoBehaviour {

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
        if (IsSelecting && Input.GetKeyDown(KeyCode.Escape))
        {
            SelectCharacter(null);
        }
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
        // open panel or close panel
        if (selectedCharacter == null)
        {
            panelAnimator.SetTrigger("Out");
            return;
        }
        else if (!panelAnimator.GetCurrentAnimatorStateInfo(0).IsName("In"))
        {
            panelAnimator.SetTrigger("In");
        } 

        // update panel values
        Character characterObject = selectedCharacter.Char;
        nameText.text = characterObject.Name;
        avatarImage.sprite = characterObject.Avatar;
        healthText.text = characterObject.Health.ToString("0");
        attackText.text = characterObject.AttackPower.ToString("0.#");
        armorText.text = characterObject.Armor.ToString("0.#");
        characterEquipped.GetComponent<InventoryScript>().Inventory = characterObject.Equipped;

    }
}
