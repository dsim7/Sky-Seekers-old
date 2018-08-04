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
    private ActionTemplate _lightAttack;
    public ActionTemplate LightAttack { get { return _lightAttack; } set { _lightAttack = value; } }
    
    [SerializeField]
    private ActionTemplate _heavyAttack;
    public ActionTemplate HeavyAttack { get { return _heavyAttack; } set { _heavyAttack = value; } }

    [SerializeField]
    private ActionTemplate _specialAttack;
    public ActionTemplate SpecialAttack { get { return _specialAttack; } set { _specialAttack = value; } }

    [SerializeField]
    private ActionTemplate _supportAbility;
    public ActionTemplate SupportAbility { get { return _supportAbility; } set { _supportAbility = value; } }

    [SerializeField]
    private ActionTemplate _defensiveAbility;
    public ActionTemplate DefensiveAbility { get { return _defensiveAbility; } set { _defensiveAbility = value; } }

    public PriorityEvent<ActionInstance> OnAttackStart = new PriorityEvent<ActionInstance>();
    public PriorityEvent<ActionInstance> OnAttackConnect = new PriorityEvent<ActionInstance>();
    public PriorityEvent<ActionInstance> OnAttackDefended = new PriorityEvent<ActionInstance>();
    public PriorityEvent<ActionInstance> OnAttackMiss = new PriorityEvent<ActionInstance>();
    public PriorityEvent<ActionInstance> OnAttackHit = new PriorityEvent<ActionInstance>();

    public PriorityEvent<ActionInstance> OnEnemyAttackStart = new PriorityEvent<ActionInstance>();
    public PriorityEvent<ActionInstance> OnEnemyAttackConnect = new PriorityEvent<ActionInstance>();
    public PriorityEvent<ActionInstance> OnEnemyAttackDefended = new PriorityEvent<ActionInstance>();
    public PriorityEvent<ActionInstance> OnEnemyAttackMiss = new PriorityEvent<ActionInstance>();
    public PriorityEvent<ActionInstance> OnEnemyAttackHit = new PriorityEvent<ActionInstance>();

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
            LightAttack.Cooldown.UpdateCooldown();
        if (HeavyAttack != null)
            HeavyAttack.Cooldown.UpdateCooldown();
        if (SpecialAttack != null)
            SpecialAttack.Cooldown.UpdateCooldown();
        if (SupportAbility != null)
            SupportAbility.Cooldown.UpdateCooldown();
        if (DefensiveAbility != null)
            DefensiveAbility.Cooldown.UpdateCooldown();
    }

    public void DoLightAttack(Character user, Character target)
    {
        if (!IsUsingAbility)
        {
            LightAttack.ExecuteAction(user, target);
        }
    }

}
