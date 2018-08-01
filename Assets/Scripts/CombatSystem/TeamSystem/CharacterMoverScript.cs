using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoverScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _teamPositions;

    private Transform _targetPosition;

    private TeamPositions _teamPositionsScript;
    private float _speed = 30f;
    private bool _moving;

    private bool _stayInAttackRunning = false;
    private float _stayInAttackTime = 1f;
    private float _stayInAttackCounter = 0f;
    
    void Start () {
        _teamPositionsScript = _teamPositions.GetComponent<TeamPositions>();
    }
	
	void Update () {
        Move();

        UpdateStayAtAttackTimer();
    }

    void Move()
    {
        if (_moving && _targetPosition != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, Time.deltaTime * _speed);
            _moving = Vector3.Distance(transform.position, _targetPosition.position) > 0.1f;
        }
    }
    
    
    void UpdateStayAtAttackTimer()
    {
        if (_stayInAttackRunning && _stayInAttackCounter > 0)
        {
            _stayInAttackCounter -= Time.deltaTime;
            if (_stayInAttackCounter < 0)
            {
                _targetPosition = _teamPositionsScript.MainPosition;
                _moving = true;
            }
        }
    }

    public void GoToSupportPosition()
    {
        _targetPosition = _teamPositionsScript.SupportPosition;
        _moving = true;
    }

    public void GoToHoldPosition()
    {
        _stayInAttackCounter = _stayInAttackTime;
        _stayInAttackRunning = true;
    }

    public void GoToAttackPosition()
    {
        _stayInAttackRunning = false;
                
        _targetPosition = _teamPositionsScript.MainAttackPosition;
        _moving = true;
    }
}
