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
        _unit.UnitAnimator.ShowIdle();
    }

    public void Exit()
    {
        _unit.UnitAnimator.ResetTrigger();
    }

    public void FixedUpdate()
    {
        _unit.CheckDistanceToEnemy();
    }
}
