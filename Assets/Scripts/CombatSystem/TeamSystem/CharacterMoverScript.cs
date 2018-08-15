using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoverScript : MonoBehaviour
{
    [SerializeField]
    private TeamPositions _teamPositions;   // Object containing all transform points

    private Transform _teamRankPosition;    // Transform of the position of the character's rank (main/support)
    private Transform _targetPosition;      // Current position, same as _teamRank, but might be in attack position
    
    private float _speed = 30f;
    private bool _moving = false;

    // When performing actions, the character moves to attack position and stays there.
    // When the action completes, a timer starts.
    // When the timer completes the character returns to hold position.
    // Performing subsequent actions while in attack position restarts the timer. 
    private bool _stayInAttackTimerRunning = false;
    private float _stayInAttackTime = 1.5f;
    private float _stayInAttackTimer = 0f;
	
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
        if (_stayInAttackTimerRunning && _stayInAttackTimer > 0)
        {
            _stayInAttackTimer -= Time.deltaTime;
            if (_stayInAttackTimer < 0)
            {
                ResetStayInAttackCounter();
                _targetPosition = _teamRankPosition;
                _moving = true;
            }
        }
    }

    public void GoToSupportPosition()
    {
        ResetStayInAttackCounter();
        _teamRankPosition = _teamPositions.SupportPosition;
        _targetPosition = _teamPositions.SupportPosition;
        _moving = true;
    }

    public void GoToMainPosition()
    {
        ResetStayInAttackCounter();
        _teamRankPosition = _teamPositions.MainPosition;
        _targetPosition = _teamPositions.MainPosition;
        _moving = true;
    }

    public void GoBack()
    {
        // Support character goes back to support position immediately
        if (_teamRankPosition == _teamPositions.SupportPosition)
        {
            GoToSupportPosition();
        }
        else
        {
            // Main character starts timer to return to main position
            _stayInAttackTimerRunning = true;
        }
    }

    public void GoToAttackPosition()
    {
        ResetStayInAttackCounter();
        // Move to attack position
        _targetPosition = _teamPositions.MainAttackPosition;
        _moving = true;
    }

    void ResetStayInAttackCounter()
    {
        _stayInAttackTimerRunning = false;
        _stayInAttackTimer = _stayInAttackTime;
    }
}
