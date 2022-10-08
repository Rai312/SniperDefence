using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FenceState;

public class FenceStateMachine : MonoBehaviour
{
    [SerializeField] private Fencing _fencing;

    private Dictionary<Type, IFenceState> _statesMap;
    private IFenceState _currentState;

    private void Awake()
    {
        InitStates();
    }

    private void OnEnable()
    {
        //_fencing.Waiting += SetWaitingState;
        //_fencing.TargetSearching += SetTargetSearchState;
        //_fencing.TargetAssigned += SetMovementState;
        //_fencing.Fight += SetFightingState;
        //_fencing.Died += SetDiedState;
    }

    private void OnDisable()
    {
        //_fencing.Waiting -= SetWaitingState;
        //_fencing.TargetSearching -= SetTargetSearchState;
        //_fencing.TargetAssigned -= SetMovementState;
        //_fencing.Fight -= SetFightingState;
        //_fencing.Died -= SetDiedState;
    }

    private void Start()
    {
        SetStateByDefault();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IFenceState>()
        {
            [typeof(StartState)] = new StartState(_fencing),
            [typeof(WaitingState)] = new WaitingState(_fencing),
            [typeof(FightingState)] = new FightingState(_fencing),
            [typeof(DiedState)] = new DiedState(_fencing),
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

    public void SetDiedState()
    {
        var state = GetState<DiedState>();
        SetState(state);
    }

    public void SetFightingState()
    {
        var state = GetState<FightingState>();
        SetState(state);
    }

    private void SetStateByDefault()
    {
        //SetWaitingState();
        SetStartState();
    }

    private void SetState(IFenceState newState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    private IFenceState GetState<T>() where T : IFenceState
    {
        var type = typeof(T);
        return _statesMap[type];
    }
}
