using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    private Dictionary<Type, IUnitState> _statesMap;
    private IUnitState _currentState;

    private void Awake()
    {
        InitStates();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        SetStateByDefault();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IUnitState>()
        {
            [typeof(WaitingState)] = new WaitingState(_unit),
            [typeof(TargetSearchState)] = new TargetSearchState(_unit),
            [typeof(MovementState)] = new MovementState(_unit),
            [typeof(FightingState)] = new FightingState(_unit),
            [typeof(DiedState)] = new DiedState(_unit)
        };
    }

    public void SetWaitingState()
    {
        var state = GetState<WaitingState>();
        SetState(state);
    }

    public void SetTargetSearchState()
    {
        var state = GetState<TargetSearchState>();
        SetState(state);
    }

    public void SetMovementState()
    {
        var state = GetState<MovementState>();
        SetState(state);
    }

    public void SetFightingState()
    {
        var state = GetState<FightingState>();
        SetState(state);
    }

    public void SetDiedState()
    {
        var state = GetState<DiedState>();
        SetState(state);
    }

    private void SetStateByDefault()
    {
        SetWaitingState();
    }

    private void SetState(IUnitState newState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    private IUnitState GetState<T>() where T : IUnitState
    {
        var type = typeof(T);
        return _statesMap[type];
    }
}
