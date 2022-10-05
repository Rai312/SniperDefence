using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialState : IGameState
{
    private readonly UI _uI;
    private readonly Battle _battle;

    public InitialState(UI ui,Battle battle)
    {
        _uI = ui;
        _battle = battle;
    }

    public void Enter()
    {
        //Debug.Log("InitialState - Enter");
        _battle.StartBattle();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
