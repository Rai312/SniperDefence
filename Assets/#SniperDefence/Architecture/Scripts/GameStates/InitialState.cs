using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialState : IGameState
{
    private readonly UI _uI;
    private readonly Battle _battle;
    private readonly PlaceHolder _placeHolder;

    public InitialState(UI ui,Battle battle, PlaceHolder placeHolder)
    {
        _uI = ui;
        _battle = battle;
        _placeHolder = placeHolder;
    }

    public void Enter()
    {
        //Debug.Log("InitialState - Enter");
        _uI.OpeningMenu.Show();

        _battle.InitializeEnemies();
        //_battle.WavesManager.InitializeWaves();
    }

    public void Exit()
    {
        //Debug.Log("InitialState - Exit");
    }
}
