using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeamScript : MonoBehaviour
{
    [SerializeField]
    private TeamScript _enemyTeam;
    public TeamScript EnemyTeam { get { return _enemyTeam; } set { _enemyTeam = value; } }
    [SerializeField]
    private CombatCharacterScript _main;
    public CombatCharacterScript Main { get { return _main; } set { _main = value; } }
    [SerializeField]
    private CombatCharacterScript _support;
    public CombatCharacterScript Support { get { return _support; } set { _support = value; } }

    void Awake()
    {
        TeamActionBar actionBar = GetComponent<TeamActionBar>();
        if (actionBar != null)
        {
            actionBar.UpdateButtons(_main.Character, _support.Character);
        }

        _main.Character.OnDeath.AddListener(SwapOnDeath);
        _support.Character.OnDeath.AddListener(SwapOnDeath);

        _main.GetComponent<CharacterMoverScript>().GoToMainPosition();
        _support.GetComponent<CharacterMoverScript>().GoToSupportPosition();
    }

    public void DoLightAttack()
    {
        _main.ExecuteAction(_main.Character.LightAttack, this);
    }

    public void DoHeavyAttack()
    {
        _main.ExecuteAction(_main.Character.HeavyAttack, this);
    }

    public void DoSpecialAttack()
    {
        _main.ExecuteAction(_main.Character.SpecialAttack, this);
    }

    public void DoDefensiveAbility()
    {
        _main.ExecuteAction(_main.Character.DefensiveAbility, this);
    }

    public void DoSupportAbility()
    {
        _support.ExecuteAction(_support.Character.SupportAbility, this);
    }

    public void Swap()
    {
        if (!_support.Character.IsDead)
        {
            // Interrupt actions in progress
            _main.InterruptAnimateAction();
            _support.InterruptAnimateAction();

            // Swap characters
            CombatCharacterScript temp = _main;
            _main = _support;
            _support = temp;

            // Move character figures
            _support.GetComponent<CharacterMoverScript>().GoToSupportPosition();
            _main.GetComponent<CharacterMoverScript>().GoToMainPosition();

            // Update action bar
            TeamActionBar actionBar = GetComponent<TeamActionBar>();
            if (actionBar != null)
            {
                actionBar.UpdateButtons(_main.Character, _support.Character);
            }
        }
    }

    void SwapOnDeath()
    {
        StartCoroutine(WaitThenSwap());
    }

    IEnumerator WaitThenSwap()
    {
        yield return new WaitForSeconds(1.5f);
        Swap();
    }
}
