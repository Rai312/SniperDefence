using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private UI _uI;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private Sniper _sniper;
    [SerializeField] private Battle _battle;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TeamDefender _teamDefender;
    [SerializeField] private TeamEnemy _teamEnemy;
    

    private Dictionary<Type, IGameState> _statesMap;
    private IGameState _currentState;

    private void Awake()
    {
        InitStates();
    }

    private void OnEnable()
    {
        //тут на все подписываемся
    }

    private void OnDisable()
    {
        //тут от всего отписываемся
    }

    private void Start()
    {
        SetStateByDefault();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IGameState>
        {
            [typeof(InitialState)] = new InitialState(_uI, _battle),
            [typeof(OpeningState)] = new OpeningState(_uI),
            [typeof(PlayState)] = new PlayState(_uI, _spawner, _teamEnemy, _teamDefender),
            [typeof(SniperShootingState)] = new SniperShootingState(_uI, _cameraController, _sniper),
            [typeof(PauseState)] = new PauseState(_uI),
            [typeof(EndLevelState)] = new EndLevelState(_uI),
            [typeof(FailState)] = new FailState(_uI),
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

    private void SetPlayState()
    {
        var state = GetState<PlayState>();
        SetState(state);
    }

    private void SetPauseState()
    {
        var state = GetState<PauseState>();
        SetState(state);
    }

    private void SetEndlevelState()
    {
        var state = GetState<EndLevelState>();
        SetState(state);
    }

    private void SetFailState()
    {
        var state = GetState<FailState>();
        SetState(state);
    }
    private void SetSniperShootingState()
    {
        var state = GetState<SniperShootingState>();
        SetState(state);
    }

    private void SetStateByDefault()
    {
        SetPlayState();
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
