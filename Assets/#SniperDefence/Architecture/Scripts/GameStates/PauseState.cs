using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IGameState
{
    private readonly UI _uI;

    public PauseState(UI uI)
    {
        _uI = uI;
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
