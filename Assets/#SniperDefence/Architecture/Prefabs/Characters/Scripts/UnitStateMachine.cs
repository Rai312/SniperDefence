using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnitState;

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
        _unit.Waiting += SetWaitingState;
        _unit.TargetSearching += SetTargetSearchState;
        _unit.TargetAssigned += SetMovementState;
        _unit.Fight += SetFightingState;
        _unit.Died += SetDiedState;
    }

    private void OnDisable()
    {
        _unit.Waiting -= SetWaitingState;
        _unit.TargetSearching -= SetTargetSearchState;
        _unit.TargetAssigned -= SetMovementState;
        _unit.Fight -= SetFightingState;
        _unit.Died -= SetDiedState;
    }

    private void Start()
    {
        SetStateByDefault();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IUnitState>()
        {
            [typeof(StartState)] = new StartState(_unit),
            [typeof(WaitingState)] = new WaitingState(_unit),
            [typeof(TargetSearchState)] = new TargetSearchState(_unit),
            [typeof(MovementState)] = new MovementState(_unit),
            [typeof(FightingState)] = new FightingState(_unit),
            [typeof(DiedState)] = new DiedState(_unit)
        };
    }
    
    public void SetStartState()
    {
        var state = GetState<StartState>();
        SetState(state);
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
        //SetWaitingState();
        SetStartState();
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

    private void FixedUpdate()
    {
        if (_currentState != null)
            _currentState.FixedUpdate();
    }
}