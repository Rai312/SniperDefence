using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialState : IGameState
{
    private readonly UI _uI;
    private readonly Battle _battle;
    private readonly Spawner _spawner;

    public InitialState(UI ui,Battle battle, Spawner spawner)
    {
        _uI = ui;
        _battle = battle;
        _spawner = spawner;
    }

    public void Enter()
    {
        //Debug.Log("InitialState - Enter");
        _spawner.Initialize();
        _uI.OpeningMenu.Show();
        //_battle.StartBattle();
        _battle.Initialization();
    }

    public void Exit()
    {
        //Debug.Log("InitialState - Exit");
    }
}
