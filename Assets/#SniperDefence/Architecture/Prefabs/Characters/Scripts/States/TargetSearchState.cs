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
        _unit.TrySetTarget();
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {

    }
}
