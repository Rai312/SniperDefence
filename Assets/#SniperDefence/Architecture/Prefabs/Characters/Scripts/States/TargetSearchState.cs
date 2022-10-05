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
        if (_unit is Enemy)
        {
            Debug.Log("TargetSearchState - Enter - " + _unit);
        }

        //if (_unit is Defender)
        //{
        //    _unit.TrySetTarget();
        //}
        _unit.TrySetTarget();
    }

    public void Exit()
    {
        if (_unit is Enemy)
        {
            Debug.Log("TargetSearchState - Exit - " + _unit);
        }
    }

    public void FixedUpdate()
    {

    }
}
