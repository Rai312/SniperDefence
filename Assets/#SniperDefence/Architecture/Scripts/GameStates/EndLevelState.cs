using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelState : IGameState
{
    private readonly UI _uI;

    public EndLevelState(UI ui)
    {
        _uI = ui;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
