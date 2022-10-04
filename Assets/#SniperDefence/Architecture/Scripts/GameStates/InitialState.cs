using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialState : IGameState
{
    private readonly Battle _battle;

    public InitialState(Battle battle)
    {
        _battle = battle;
    }

    public void Enter()
    {
        Debug.Log("InitialState - Enter");
        _battle.StartBattle();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
