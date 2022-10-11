using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private UI _uI;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private Sniper _sniper;
    [SerializeField] private Battle _battle;
    [SerializeField] private PlaceHolder _placeHolder;
    [SerializeField] private TeamDefender _teamDefender;
    [SerializeField] private TeamEnemy _teamEnemy;
    [SerializeField] private DragAndDropSystem _dragAndDropSystem;
    
    private Dictionary<Type, IGameState> _statesMap;
    private IGameState _currentState;

    private void Awake()
    {
        InitStates();
        SetStateByDefault();
    }

    private void OnEnable()
    {
        _uI.OpeningMenu.StartButton.onClick.AddListener(SetPlayState);
        _uI.SniperMenu.StartButton.onClick.AddListener(SetSniperShootingState);
    }

    private void OnDisable()
    {
        _uI.OpeningMenu.StartButton.onClick.RemoveListener(SetPlayState);
        _uI.SniperMenu.StartButton.onClick.RemoveListener(SetSniperShootingState);
    }

    private void Start()
    {
        SetOpeningState();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IGameState>
        {
            [typeof(InitialState)] = new InitialState(_uI, _battle, _placeHolder),
            [typeof(OpeningState)] = new OpeningState(_uI),
            [typeof(PlayState)] = new PlayState(_uI, _placeHolder, _battle),
            [typeof(SniperShootingState)] = new SniperShootingState(_uI, _cameraController, _sniper, _placeHolder, _teamEnemy, _teamDefender),
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
        //SetPlayState();
        //SetOpeningState();
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
