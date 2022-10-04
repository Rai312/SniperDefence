using UnityEngine;

public class TargetSearchState : IUnitState
{
    private Unit _unit;

    public TargetSearchState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        Debug.Log("TargetSearch - Enter");
        _unit.SetTarget();
    }

    public void Exit()
    {
        Debug.Log("TargetSearch - Enter");
    }

    public void FixedUpdate()
    {

    }
}
