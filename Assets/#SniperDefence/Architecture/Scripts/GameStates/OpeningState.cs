using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningState : IGameState
{
    private readonly UI _uI;

    public OpeningState(UI uI)
    {
        _uI = uI;
    }

    public void Enter()
    {
        _uI.OpeningMenu.Show();
        //Debug.Log("Opening State - Enter");

    }

    public void Exit()
    {
        _uI.OpeningMenu.Hide();
        //Debug.Log("Opening State - Exit");

    }
}
