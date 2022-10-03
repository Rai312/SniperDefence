using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private UI _uI;
    

    private Dictionary<Type, IGameState> _statesMap;
    private IGameState _currentState;

    private void Awake()
    {
        InitStates();
    }

    private void OnEnable()
    {
        //��� �� ��� �������������
    }

    private void OnDisable()
    {
        //��� �� ����� ������������
    }

    private void Start()
    {
        SetStateByDefault();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IGameState>
        {
            [typeof(InitialState)] = new InitialState(),
            [typeof(OpeningState)] = new OpeningState(),
            [typeof(PlayState)] = new PlayState(),
            [typeof(PauseState)] = new PauseState(),
            [typeof(EndLevelState)] = new EndLevelState(),
            [typeof(FailState)] = new FailState(),
        };
    }

    private void SetInitialState()
    {
        var state = GetState<InitialState>();
        SetState(state);
    }

    private void SetOpeningState()
    {
        var state = GetState<OpeningState>();
        SetState(state);
    }

    public void SetPlayState()
    {
        var state = GetState<PlayState>();
        SetState(state);
    }

    private void SetPauseState()
    {
        var state = GetState<PauseState>();
        SetState(state);
    }

    public void SetEndlevelState()
    {
        var state = GetState<EndLevelState>();
        SetState(state);
    }

    public void SetFailState()
    {
        var state = GetState<FailState>();
        SetState(state);
    }

    private void SetStateByDefault()
    {
        SetInitialState();
    }

    private void SetState(IGameState newState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    private IGameState GetState<T>() where T : IGameState
    {
        var type = typeof(T);
        return _statesMap[type];
    }
}
