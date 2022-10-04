using UnityEngine;

public class WaitingState : IUnitState
{
    private Unit _unit;

    public WaitingState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        //Debug.Log("WaitingState - Enter");
    }

    public void Exit()
    {
        //Debug.Log("WaitingState - Exit");
    }

    public void FixedUpdate()
    {
    }
}
