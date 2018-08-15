using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
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
    private float _currentHealth;
    public float CurrentHealth
    {
        get { return _currentHealth; }

        set
        {
            if (!_isDead)
            {
                _currentHealth = Mathf.Clamp(value, 0, _health);
                CheckHealth();
            }
        }
    }

    [SerializeField]
    private float _attackPower;
    public float AttackPower { get { return _attackPower; } set { _attackPower = value; } }

    [SerializeField]
    private float _armor;
    public float Armor { get { return _armor; } set { _armor = value; } }

    [SerializeField]
    private bool _isDefending;
    public bool IsDefending { get { return _isDefending; } set { _isDefending = value; } }

    [SerializeField]
    private bool _isDead;
    public bool IsDead { get { return _isDead; } set { _isDead = value; } }

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

    public ActionModEvent OnActionStart = new ActionModEvent();
    public ActionModEvent OnActionComplete = new ActionModEvent();

    public ActionModEvent OnEnemyActionStart = new ActionModEvent();
    public ActionModEvent OnEnemyActionComplete = new ActionModEvent();

    [HideInInspector]
    public UnityEvent OnDeath = new UnityEvent();

    void OnEnable()
    {
        _currentHealth = _health;
        _isDead = false;
    }

    public void RegisterMods()
    {
        Equipped.Slots.ForEach(slot => ((SigilTemplate)slot.Value.Template).ModifyCharacter(this));
    }

    public void UnregisterMods()
    {
        Equipped.Slots.ForEach(slot => ((SigilTemplate)slot.Value.Template).UnmodifyCharacter(this));
    }

    public void CheckHealth()
    {
        if (_currentHealth == 0)
        {
            OnDeath.Invoke();
            _isDead = true;
        }
        else if (_isDead)
        {
            _isDead = false;
        }
    }
}
