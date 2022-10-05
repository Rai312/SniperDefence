using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : IGameState
{
    private readonly UI _uI;
    private readonly Spawner _spawner;
    private readonly TeamEnemy _teamEnemy;
    private readonly TeamDefender _teamDefender;

    public PlayState(UI uI, Spawner spawner, TeamEnemy teamEnemy, TeamDefender teamDefender)
    {
        _uI = uI;
        _spawner = spawner;
        _teamEnemy = teamEnemy;
        _teamDefender = teamDefender;
    }

    public void Enter()
    {
        //Debug.Log("PlayState - Enter");
        _spawner.Spawned += OnSpawned;
    }

    public void Exit()
    {
        //Debug.Log("PlayState - Exit");
        _spawner.Spawned -= OnSpawned;
    }

    private void OnSpawned(Defender defender)
    {
        defender.Initialize(_teamEnemy.Units);
        _teamDefender.AddSpawned(defender);

    }
}
