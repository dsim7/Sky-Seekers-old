using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject {

    [Header("Appearance")]
    [SerializeField]
    private string _name;
    public string Name { get { return _name; } set { _name = value; } }

    [SerializeField]
    private Sprite _avatar;
    public Sprite Avatar { get { return _avatar; } set { _avatar = value; } }

    [Header("Stats")]
    [SerializeField]
    private float _health;
    public float Health { get { return _health; } set { _health = value; } }

    [SerializeField]
    private float _curHealth;
    public float CurrentHealth { get { return _curHealth; } set { _curHealth = value; } }

    [SerializeField]
    private float _attackPower;
    public float AttackPower { get { return _attackPower; } set { _attackPower = value; } }

    [SerializeField]
    private float _armor;
    public float Armor { get { return _armor; } set { _armor = value; } }

    [Header("Equipment")]
    [SerializeField]
    private Inventory _equipped;
    public Inventory Equipped { get { return _equipped; } set { _equipped = value; } }

    [Header("Abilities")]
    [SerializeField]
    private AttackTemplate _lightAttack;
    public AttackTemplate LightAttack { get { return _lightAttack; } set { _lightAttack = value; } }
    
    [SerializeField]
    private AttackTemplate _heavyAttack;
    public AttackTemplate HeavyAttack { get { return _heavyAttack; } set { _heavyAttack = value; } }

    [SerializeField]
    private AttackTemplate _specialAttack;
    public AttackTemplate SpecialAttack { get { return _specialAttack; } set { _specialAttack = value; } }

    [SerializeField]
    private AbilityTemplate _supportAbility;
    public AbilityTemplate SupportAbility { get { return _supportAbility; } set { _supportAbility = value; } }

    [SerializeField]
    private AbilityTemplate _defensiveAbility;
    public AbilityTemplate DefensiveAbility { get { return _defensiveAbility; } set { _defensiveAbility = value; } }

    public PriorityEvent<Attack> OnAttackStart = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnAttackConnect = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnAttackDefended = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnAttackMiss = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnAttackHit = new PriorityEvent<Attack>();

    public PriorityEvent<Attack> OnEnemyAttackStart = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnEnemyAttackConnect = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnEnemyAttackDefended = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnEnemyAttackMiss = new PriorityEvent<Attack>();
    public PriorityEvent<Attack> OnEnemyAttackHit = new PriorityEvent<Attack>();

    //public PriorityEvent<Utility> OnSupportUsed = new PriorityEvent<Utility>();

    //public PriorityEvent<Utility> OnDefensiveUsed = new PriorityEvent<Utility>();

    [SerializeField]
    private bool _isUsingAbility = false;
    public bool IsUsingAbility { get { return _isUsingAbility; } set { _isUsingAbility = value; } }

    [SerializeField]
    private bool _isDefending;
    public bool IsDefending { get { return _isDefending; } set { _isDefending = value; } }

    public void RegisterMods()
    {
        Equipped.Slots.ForEach(slot => ((SigilTemplate)slot.Value.Template).ModifyCharacter(this));
    }

    public void UnregisterMods()
    {
        Equipped.Slots.ForEach(slot => ((SigilTemplate)slot.Value.Template).UnmodifyCharacter(this));
    }

    public void UpdateCooldowns()
    {
        if (LightAttack != null)
            LightAttack.Cooldowner.UpdateCooldown();
        if (HeavyAttack != null)
            HeavyAttack.Cooldowner.UpdateCooldown();
        if (SpecialAttack != null)
            SpecialAttack.Cooldowner.UpdateCooldown();
        if (SupportAbility != null)
            SupportAbility.Cooldowner.UpdateCooldown();
        if (DefensiveAbility != null)
            DefensiveAbility.Cooldowner.UpdateCooldown();
    }

    public void DoLightAttack(Character user, Character target)
    {
        if (!IsUsingAbility)
        {
            LightAttack.StartAction(user, target);
        }
    }

}
